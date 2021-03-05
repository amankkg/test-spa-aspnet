using System;
using System.Collections.Generic;
using Zags.Web.Models;

namespace Zags.Web.Services
{
    public class PinService
    {
        private readonly string postfix;
        private readonly string birthDateFormat;
        private readonly int idPadSize;
        private readonly Dictionary<Gender, string> genderMarkMap;

        public PinService(
            Dictionary<Gender, string> genderMarkMap,
            string postfix = "",
            string birthDateFormat = "ddMMyyyy",
            int idPadSize = 5)
        {
            this.genderMarkMap = genderMarkMap;
            this.postfix = postfix;
            this.birthDateFormat = birthDateFormat;
            this.idPadSize = idPadSize;
        }

        public string Generate(Gender gender, DateTime birthDate, int id)
        {
            var genderToken = genderMarkMap[gender];
            var birthDateToken = birthDate.ToString(birthDateFormat);
            var idToken = id.ToString().PadLeft(idPadSize, '0');

            return $"{genderToken}{birthDateToken}{idToken}{postfix}";
        }
    }
}
