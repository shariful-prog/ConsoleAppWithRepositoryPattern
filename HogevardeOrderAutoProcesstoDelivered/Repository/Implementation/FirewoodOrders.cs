using HogevardeOrderAutoProcesstoDelivered.Data;
using HogevardeOrderAutoProcesstoDelivered.Models;
using HogevardeOrderAutoProcesstoDelivered.Repository.Interface;
using HogevardeOrderAutoProcesstoDelivered.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HogevardeOrderAutoProcesstoDelivered.Setting;
using Microsoft.Data.SqlClient;
using System.Data;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
namespace HogevardeOrderAutoProcesstoDelivered.Repository.Implementation
{
    class FirewoodOrders : IFirewoodOrders
    {
        private readonly hogevardeDbContext _context;
        public FirewoodOrders(hogevardeDbContext context)
        {
            _context = context;
        }

        public List<FirewoodOrderVM> GetOrderedOrderByDate(string orderDate)
        {
            #region getbyOrderDateQuery

            List<FirewoodOrderVM> dataList=new List<FirewoodOrderVM>();
            try
            {
                dataList = (from a in _context.FirewoodOrders
                          join b in _context.FirewoodOrderDetails on a.Id equals b.OrderId
                          join user in _context.AspNetUsers on a.CreatedBy equals user.Id
                          where a.OrderDate == orderDate && a.OrderStatus == "Ordered"
                          select new FirewoodOrderVM
                          {
                              OrderId = a.Id,
                              PaymentId = a.PaymentId,
                              PaidAmount = b.PaidAmount,
                              Phone = user.PhoneNumber,
                              ServiceTypeName = a.ServiceType,
                              OrderStatus = a.OrderStatus,
                              UpdatedOn=a.UpdatedOn,
                              PaymentStatus=b.PaymentStatus,
                              DueAmount=b.DueAmount,
                              UpdatedBy=a.CreatedBy
                          }).ToList();
                
               
            }
            catch(Exception ex)
            {
                //Console.Read();
                throw ex;
            }

            #endregion


            return dataList;
        }



        public Response UpdatePaymentStatus(FirewoodOrderVM pay)
        {
            try
            {
                pay.OrderStatus = "Delivered";
                var historyId = ObjectId.GenerateNewId().ToString();
                SqlParameter[] @params =
                {
                new SqlParameter("@pUpdatedBy", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = "AutoProcess"},
                new SqlParameter("@pUpdatedOn", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = pay.UpdatedOn},
                new SqlParameter("@pOrderId", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = pay.OrderId},
                new SqlParameter("@pPaymentId", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = pay.PaymentId},
                new SqlParameter("@pOrderStatus", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = pay.OrderStatus},
                new SqlParameter("@pPaymentStatus", SqlDbType.NVarChar) {Direction = ParameterDirection.Input,  SqlValue = pay.PaymentStatus},
                new SqlParameter("@pPaidAmount", SqlDbType.Decimal) {Direction = ParameterDirection.Input,  SqlValue = pay.PaidAmount},
                new SqlParameter("@pDueAmount", SqlDbType.Decimal) {Direction = ParameterDirection.Input, SqlValue = pay.DueAmount},
                new SqlParameter("@pHistoryId", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = historyId},
                new SqlParameter("@pOutPut", SqlDbType.NVarChar, 250) {Direction = ParameterDirection.Output, SqlValue = ""}
            };
                string sqlQuery =
                    @"EXECUTE dbo.UpdatePaymentStatus @pUpdatedBy,@pUpdatedOn, @pOrderId, @pPaymentId, @pOrderStatus, 
                                                      @pPaymentStatus,@pPaidAmount, @pDueAmount, @pHistoryId, @pOutPut OUT";
                var result = _context.Database.ExecuteSqlRaw(sqlQuery, @params);
                return new Response() { Status = Status.Success, Message = "Success", Data = result };
            }
            catch (Exception ex)
            {
                var messages = new List<string>();
                return new Response() { Status = Status.BadRequest, Message = "Bad Request", Data = string.Join("", messages) };
            }
        }
    }
}
