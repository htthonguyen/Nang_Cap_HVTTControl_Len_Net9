using System;
using System.Text;


namespace HVTT.UI.ContentManager


{
    /// <summary>
    /// Represents a extended content block interface for advanced layout information.
    /// </summary>
    public interface IBlockExtended : IBlock
    {
        bool IsBlockElement { get;}
        bool IsNewLineAfterElement { get;}
        bool CanStartNewLine { get; }
    }
}
