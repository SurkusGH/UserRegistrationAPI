﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationAPI.Data.Data
{
    public class DataSheet
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentificationNumber { get; set; }

        public byte[] ImageData { get; set; }

        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
