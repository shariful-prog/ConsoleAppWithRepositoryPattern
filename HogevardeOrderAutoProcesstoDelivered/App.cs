using HogevardeOrderAutoProcesstoDelivered.Data;
using HogevardeOrderAutoProcesstoDelivered.Repository.Interface;
using HogevardeOrderAutoProcesstoDelivered.Setting;
using HogevardeOrderAutoProcesstoDelivered.Test;
using HogevardeOrderAutoProcesstoDelivered.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogevardeOrderAutoProcesstoDelivered
{
    class App
    {
        private readonly IFirewoodOrders _firewoodRepository;
        private readonly ICleaningOrder _cleanRepository;
        public App(IFirewoodOrders firewoodRepository,ICleaningOrder cleanRepo)
        {
            _firewoodRepository = firewoodRepository;
            _cleanRepository = cleanRepo;
        }



        private void FirewoodOrder_AutoProcess()
        {
            Response result = new Response() { Status = Status.Success };
            #region orderDataGet
            string previousDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            List<FirewoodOrderVM> orderData = _firewoodRepository.GetOrderedOrderByDate(previousDate);

            int count = 0;

            // sending order to vipps capture
            foreach (var item in orderData)
            {
                if (count % 3 == 0)
                {
                    Task.Delay(1000);
                }
                count++;

                if (item.OrderStatus == BasicSetting.OrderStatus)
                {
         
                    int amount = Convert.ToInt32(item.PaidAmount * 100);

                    //Commented the actual VippsPayment Process
                    //string url = BasicSetting.PaymentApiUrl + $"CapturePay.aspx?orderid={vm.PaymentId}&amount={amount}&msisdn={vm.Phone}";
                    //using (var client = new HttpClient())
                    //{
                    //    var response = client.GetAsync(url).Result;
                    //    var res = response.Content.ReadAsStringAsync().Result;
                    //    //if (!res.ToLower().Contains("capture"))
                    //    if (!(res.ToLower() == "capture" || res.ToLower() == "captured"))
                    //    {
                    //        result.Status = Status.BadRequest; result.Message = "Invalid payment info";
                    //        result.Error = res;
                    //        return Ok(result);
                    //    }
                    //}

                    if (result.Status == Status.Success)
                    {
                        result = _firewoodRepository.UpdatePaymentStatus(item);

                    }

                }


            }


            #endregion
        }

        private void CleaningOrder_AutoProcess()
        {
            Response result = new Response() { Status = Status.Success };
            #region orderDataGet
            string previousDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            List<CleaningOrderVM> orderData = _cleanRepository.GetOrderedOrderByDate(previousDate);

            int count = 0;

            // sending order to vipps capture
            foreach (var item in orderData)
            {
                if (count % 3 == 0)
                {
                    Task.Delay(1000);
                }
                count++;

                if (item.OrderStatus == BasicSetting.OrderStatus)
                {

                    int amount = Convert.ToInt32(item.PaidAmount * 100);

                    //Commented the actual VippsPayment Process
                    //string url = BasicSetting.PaymentApiUrl + $"CapturePay.aspx?orderid={vm.PaymentId}&amount={amount}&msisdn={vm.Phone}";
                    //using (var client = new HttpClient())
                    //{
                    //    var response = client.GetAsync(url).Result;
                    //    var res = response.Content.ReadAsStringAsync().Result;
                    //    //if (!res.ToLower().Contains("capture"))
                    //    if (!(res.ToLower() == "capture" || res.ToLower() == "captured"))
                    //    {
                    //        result.Status = Status.BadRequest; result.Message = "Invalid payment info";
                    //        result.Error = res;
                    //        return Ok(result);
                    //    }
                    //}

                    //Vipps Payment process end here


                    if (result.Status == Status.Success)
                    {
                        result = _cleanRepository.UpdatePaymentStatus(item);

                    }

                }


            }


            #endregion
        }

        public  void AppRun()
        {
            Console.WriteLine("Auto Order capturing process started");
            FirewoodOrder_AutoProcess();
            CleaningOrder_AutoProcess();

        }

  
    }
}
