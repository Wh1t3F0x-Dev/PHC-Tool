using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHCTool
{
    internal class InfoCelda
    {
        public bool notApplicable;
        public string tittle;
        public string subtittle;
        public string subsubtittle;
        public string description;
        public string recommendeValue;
        public string securityRationale;
        public string validation;
        public string configuration;

        public InfoCelda(bool notApplicable, string tittle, string subtittle, string subsubtittle, string description, string recommendeValue, string securityRationale, string validation, string configuration)
        {
            this.notApplicable = notApplicable;
            this.tittle = tittle;
            this.subtittle = subtittle;
            this.subsubtittle = subsubtittle;
            this.description = description;
            this.recommendeValue = recommendeValue;
            this.securityRationale = securityRationale;
            this.validation = validation;
            this.configuration = configuration;
        }
    }
}
