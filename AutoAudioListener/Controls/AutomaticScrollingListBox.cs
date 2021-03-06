﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoAudioListener.Controls {
    public class ScrollingListBox : ListBox {
        private IBindingList oldBindingList;

        public bool EnableAutomaticScrolling { get; set; } = true;

        public bool HighlightChangedItem { get; set; } =
            true; // Effective only when EnableAutomaticScrolling is true and SelectionMode.One is set

        protected override void OnDataSourceChanged(EventArgs e) {
            base.OnDataSourceChanged(e);
            UnsubscribeFromOldBindingList();
            if (DataSource is IBindingList) SubscribeToBindingList((IBindingList) DataSource);
        }

        protected void SubscribeToBindingList(IBindingList bindinglist) {
            bindinglist.ListChanged += AutomaticScrollingListBox_ListChanged;
            oldBindingList = (IBindingList) DataSource;
        }

        protected void UnsubscribeFromOldBindingList() {
            if (oldBindingList != null) {
                oldBindingList.ListChanged -= AutomaticScrollingListBox_ListChanged;
                oldBindingList = null;
            }
        }

        protected void AutomaticScrollingListBox_ListChanged(object sender, ListChangedEventArgs e) {
            if (!EnableAutomaticScrolling) return;
            if (HighlightChangedItem && SelectionMode == SelectionMode.One) {
                SelectedIndex = e.NewIndex;
            } else {
                TopIndex = e.NewIndex;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
            UnsubscribeFromOldBindingList();
        }
    }
}