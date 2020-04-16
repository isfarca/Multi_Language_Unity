using System;
using Polyglot;
using UnityEngine;

    [Serializable]
    public class LocalizationAsset
    {
        [SerializeField]
        private TextAsset textAsset;

        [SerializeField]
        private GoogleDriveDownloadFormat format = GoogleDriveDownloadFormat.CSV;

        public TextAsset TextAsset
        {
            get { return textAsset; }
            set { textAsset = value; }
        }

        public GoogleDriveDownloadFormat Format
        {
            get { return format; }
            set { format = value; }
        }
    }