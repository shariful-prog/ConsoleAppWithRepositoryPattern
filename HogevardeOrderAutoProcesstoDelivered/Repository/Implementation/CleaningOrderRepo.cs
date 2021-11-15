using HogevardeOrderAutoProcesstoDelivered.Data;
using HogevardeOrderAutoProcesstoDelivered.Repository.Interface;
using HogevardeOrderAutoProcesstoDelivered.Setting;
using HogevardeOrderAutoProcesstoDelivered.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogevardeOrderAutoProcesstoDelivered.Repository.Implementation
{
    class CleaningOrderRepo : ICleaningOrder
    {
        private readonly hogevardeDbContext _context;

        public CleaningOrderRepo(hogevardeDbContext context)
        {
            _context = context;
        }
        public List<CleaningOrderVM> GetOrderedOrderByDate(string orderDate)
        {
            #region getbyOrderDateQuery

            List<CleaningOrderVM> dataList = new List<CleaningOrderVM>();
            try
            {
                dataList = (from a in _context.CleaningOrders
                            join b in _context.CleaningOrderDetails on a.Id equals b.OrderId
                            join user in _context.AspNetUsers on a.CreatedBy equals user.Id
                            where a.OrderDate == orderDate && a.OrderStatus == "Ordered"
                            select new CleaningOrderVM
                            {
                                OrderId = a.Id,
                                PaymentId = a.PaymentId,
                                PaidAmount = b.PaidAmount,
                                Phone = user.PhoneNumber,
                                ServiceTypeName = a.ServiceType,
                                OrderStatus = a.OrderStatus,
                                UpdatedOn = a.UpdatedOn,
                                PaymentStatus = b.PaymentStatus,
                                DueAmount = b.DueAmount,
                                UpdatedBy = a.CreatedBy
                            }).ToList();


            }
            catch (Exception ex)
            {
                //Console.Read();
                throw ex;
            }

            #endregion


            return dataList;
        }

        public Response UpdatePaymentStatus(CleaningOrderVM pay)
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
                new SqlParameter("@pPaymentId", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = (object)pay.PaymentId?? DBNull.Value},
                new SqlParameter("@pOrderStatus", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = pay.OrderStatus},
                new SqlParameter("@pPaymentStatus", SqlDbType.NVarChar) {Direction = ParameterDirection.Input,  SqlValue = pay.PaymentStatus},
                new SqlParameter("@pPaidAmount", SqlDbType.Decimal) {Direction = ParameterDirection.Input,  SqlValue = pay.PaidAmount},
                new SqlParameter("@pDueAmount", SqlDbType.Decimal) {Direction = ParameterDirection.Input, SqlValue = pay.DueAmount},
                new SqlParameter("@pHistoryId", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, SqlValue = historyId},
                new SqlParameter("@pOutPut", SqlDbType.NVarChar, 250) {Direction = ParameterDirection.Output, SqlValue = ""}
            };
                string sqlQuery =
                    @"EXECUTE dbo.UpdatePaymentStatus_Cleaning @pUpdatedBy,@pUpdatedOn, @pOrderId, @pPaymentId, @pOrderStatus, 
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
