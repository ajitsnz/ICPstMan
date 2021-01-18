
using DocuSign.eSign.Model;
using Microsoft.Build.Tasks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using QaAutoTests.Dictionaries;


namespace ICPstMan.Model
{
    class BillingOrder
    {
       

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public int itemNumber { get; set; }
        public string comment { get; set; }
        public string state { get; set; }

        public BillingOrder(
                   
         
            string firstName = null,
            string lastName = null,
            string email = null,
            string phone = null,
            string city = null,
            string zipCode = null,
            string addressLine1 = null,
            string addressLine2 = null,
           int itemNumber = 1, 
           string comment = null, 
           string state = "AL")
        {
            this.firstName = firstName ?? RandomString(10);
            this.lastName = lastName ?? RandomString(10);
            this.email = email ?? "abcbsb@gmail.com";
            this.phone = phone ?? TestContext.CurrentContext.Random.GetString(10,"1234567890"); 
            this.city = city ?? RandomString(10);
            this.zipCode = zipCode ?? TestContext.CurrentContext.Random.GetString(6,"1234567890");
            this.addressLine1 = addressLine1 ?? RandomString(15);
            this.addressLine2 = addressLine2 ?? RandomString(15);
            this.itemNumber = itemNumber;
            this.comment = comment ?? RandomString(10);
            this.state = " AL";

        }

        private readonly Random _random = new Random();
       

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase = false)
        {
           
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }

}
