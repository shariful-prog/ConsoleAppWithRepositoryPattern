using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogevardeOrderAutoProcesstoDelivered.Models;
using HogevardeOrderAutoProcesstoDelivered.Setting;
using HogevardeOrderAutoProcesstoDelivered.ViewModel;

namespace HogevardeOrderAutoProcesstoDelivered.Repository.Interface
{
    interface IFirewoodOrders
    {
        List<FirewoodOrderVM> GetOrderedOrderByDate(string orderDate);
        Response UpdatePaymentStatus(FirewoodOrderVM pay);

    }
}
