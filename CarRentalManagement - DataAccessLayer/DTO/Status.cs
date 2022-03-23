﻿namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class Status
    {
        public Order orderDetails { get; set; }
        //0 - not delivered
        //1 - deliverd
        public bool DeliveryStatus { get; set; }
        //0 - not  returned
        //1 - returned
        public bool ReturnStatus { get; set; }

        
        public bool IsPending { get; set; }

    }
}