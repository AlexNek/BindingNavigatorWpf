using System;

using NetCore.Demo.Common;

namespace NetCore.Demo.Model
{
    public class CustomerItemUi : NotifyPropertyChanged
    {
        public enum EGender
        {
            Male, 
            Female,
        }
        private string mFirstname;

        private string mLastName;

        private EGender mGender;

        private Uri mWebSite;

        private bool mReceiveNewsletter;

        public string Firstname
        {
            get
            {
                return mFirstname;
            }
            set
            {
                mFirstname = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return mLastName;
            }
            set
            {
                mLastName = value;
                OnPropertyChanged();
            }
        }

        public EGender Gender
        {
            get
            {
                return mGender;
            }
            set
            {
                mGender = value;
                OnPropertyChanged();
            }
        }

        public Uri WebSite
        {
            get
            {
                return mWebSite;
            }
            set
            {
                mWebSite = value;
                OnPropertyChanged();
            }
        }

        public bool ReceiveNewsletter
        {
            get
            {
                return mReceiveNewsletter;
            }
            set
            {
                mReceiveNewsletter = value;
                OnPropertyChanged();
            }
        }
    }
}