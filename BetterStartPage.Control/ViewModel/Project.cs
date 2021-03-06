﻿using System;
using System.IO;
using System.Runtime.Serialization;

namespace BetterStartPage.Control.ViewModel
{
    [DataContract]
    class Project : ViewModelBase
    {
        private FileInfo _fileInfo;

        public string Name
        {
            get
            {
                return _fileInfo.Name;
            }
        }

        public string DirectoryName
        {
            get { return _fileInfo.DirectoryName; }
        }

        [DataMember]
        public string FullName
        {
            get { return _fileInfo.FullName; }
            set
            {
                _fileInfo = new FileInfo(value);
                OnPropertyChanged();
                OnPropertyChanged("Name");
                OnPropertyChanged("DirectoryName");
            }
        }

        public bool IsNormalFile
        {
            get
            {
                var extension = Path.GetExtension(Name);
                if (extension == null) return true;
                if (extension.EndsWith(".sln", StringComparison.InvariantCultureIgnoreCase)) return false;
                if (extension.EndsWith("proj", StringComparison.InvariantCultureIgnoreCase)) return false;
                return true;
            }
        }

        public Project()
        {
        }

        public Project(string fullName)
        {
            FullName = fullName;
        }
    }
}
