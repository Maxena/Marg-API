using System.ComponentModel;

namespace Margs.Api.Common;

public enum Gender
{
    /// <summary>
    /// Male
    /// </summary>
    [Description("Male")] Male = 1,

    /// <summary>
    /// Female
    /// </summary>
    [Description("Female")] Female = 2,
}