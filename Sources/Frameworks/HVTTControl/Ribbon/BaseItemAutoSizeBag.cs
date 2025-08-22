using System;
using System.Text;
using System.Drawing;

namespace HVTT.UI.Window.Forms
{
    #region BaseItemAutoSizeBag
    internal class BaseItemAutoSizeBag
    {
        public BaseItem Item = null;
        private bool m_SettingsRecorded;

        protected bool SettingsRecorded
        {
            get
            {
                return m_SettingsRecorded;
            }
            set
            {
                m_SettingsRecorded = value;
            }
        }

        public virtual void RecordSetting(BaseItem item)
        {
            this.Item = item;
            m_SettingsRecorded = true;
        }

        public virtual void RestoreSettings()
        {
            m_SettingsRecorded = false;
        }
    }
    #endregion

    #region ItemContainerAutoSizeBag
    internal class ItemContainerAutoSizeBag : BaseItemAutoSizeBag
    {
        private bool m_MultiLine = false;
        private HVTTOrientation m_LayoutOrientation = HVTTOrientation.Horizontal;

        public override void RecordSetting(BaseItem item)
        {
            if (this.SettingsRecorded)
                return;
            
            ItemContainer cont = item as ItemContainer;
            m_MultiLine = cont.MultiLine;
            m_LayoutOrientation = cont.LayoutOrientation;

            base.RecordSetting(item);
        }

        public override void RestoreSettings()
        {
            if (!this.SettingsRecorded) return;

            ItemContainer cont = this.Item as ItemContainer;
            cont.MultiLine = m_MultiLine;
            cont.LayoutOrientation = m_LayoutOrientation;

            base.RestoreSettings();
        }
    }
    #endregion

    #region ButtonItemAutoSizeBag
    internal class ButtonItemAutoSizeBag : BaseItemAutoSizeBag
    {
        private HVTTButtonStyle m_ButtonStyle = HVTTButtonStyle.Default;
        private ImagePosition m_ImagePosition = ImagePosition.Left;
        private Size m_ImageFixedSize = Size.Empty;

        public override void RecordSetting(BaseItem item)
        {
            if (this.SettingsRecorded)
                return;
            
            ButtonItem button = item as ButtonItem;
            m_ButtonStyle = button.ButtonStyle;
            m_ImagePosition = button.ImagePosition;
            m_ImageFixedSize = button.ImageFixedSize;

            base.RecordSetting(item);
        }

        public override void RestoreSettings()
        {
            if (!this.SettingsRecorded)
                return;

            ButtonItem button = this.Item as ButtonItem;
            bool gi = button.GlobalItem;
            button.GlobalItem = false;
            button.ButtonStyle = m_ButtonStyle;
            button.ImagePosition = m_ImagePosition;
            button.ImageFixedSize = m_ImageFixedSize;
            button.GlobalItem = gi;
            base.RestoreSettings();
        }
    }
    #endregion

    #region AutoSizeBagFactory
    internal class AutoSizeBagFactory
    {
        public static BaseItemAutoSizeBag CreateAutoSizeBag(ButtonItem item)
        {
            ButtonItemAutoSizeBag b = new ButtonItemAutoSizeBag();
            b.Item = item;
            return b;
        }

        public static ItemContainerAutoSizeBag CreateAutoSizeBag(ItemContainer item)
        {
            ItemContainerAutoSizeBag c = new ItemContainerAutoSizeBag();
            c.Item = item;
            return c;
        }
    }
    #endregion
}
