using AppWithLocks.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithLocks.Primitives
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TypeAppMode
    {
        [Description("Демо")]
        DemoMode = 0,
        [Description("Настройка")]
        WorkMode = 1
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TypeActivate
    {
        [Description("Процессор и жёсткий диск")]
        ActivateTypeProcessorAndDisk = 0,
        [Description("Процессор")]
        ActivateTypeProcessor = 1,
        [Description("Жёсткий диск")]
        ActivateTypeDisk = 2
    }
}
