using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithLocks.Infrastructure
{
    /// <summary>
    /// The kind of message box that should be shown
    /// </summary>
    public enum MessageboxKind
    {
        /// <summary>
        /// Only an OK button is shown.
        /// </summary>
        Ok = 0,

        /// <summary>
        /// An OK and cancel button are shown.
        /// </summary>
        OKCancel,

        /// <summary>
        /// Yes no and cancel buttons are shown.
        /// </summary>
        YesNoCancel,

        /// <summary>
        /// Yes and no buttons are shown.
        /// </summary>
        YesNo
    }

    /// <summary>
    /// Represents the user's response to a message box
    /// </summary>
    public enum MessageboxResponse
    {
        /// <summary>
        /// No button was pressed
        /// </summary>
        None = 0,

        /// <summary>
        /// The OK button was pressed
        /// </summary>
        Ok,

        /// <summary>
        /// The Cancel button was pressed
        /// </summary>
        Cancel,

        /// <summary>
        /// The Yes button was pressed
        /// </summary>
        Yes,

        /// <summary>
        /// The No button was pressed
        /// </summary>
        No,
    }
}
