using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIRacingTools.Sdk.Model.Enums
{
    public enum WeatherType
    {
        [Display(Name = "Generated / Dynamic Sky")]
        GeneratedDynamicSky,

        [Display(Name = "Generated / Static Sky")]
        GeneratedStaticSky,

        [Display(Name = "Specified / Dynamic Sky")]
        SpecifiedDynamicSky,

        [Display(Name = "Specified / Static Sky")]
        SpecifiedStaticSky,
    }
}
