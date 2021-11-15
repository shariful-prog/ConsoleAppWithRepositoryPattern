using HogevardeOrderAutoProcesstoDelivered.Setting;
using HogevardeOrderAutoProcesstoDelivered.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogevardeOrderAutoProcesstoDelivered.Repository.Interface
{
    interface ICleaningOrder
    {
        List<CleaningOrderVM> GetOrderedOrderByDate(string orderDate);
        Response UpdatePaymentStatus(CleaningOrderVM pay);
    }
}
