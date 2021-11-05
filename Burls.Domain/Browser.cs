﻿using Burls.Core.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Burls.Domain
{
    public class Browser : IEntity
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string ExecutablePath { get; protected set; }
        public string IconPath { get; protected set; }
        public int IconIndex { get; protected set; }
        public string ProfileArgumentName { get; protected set; }
        public virtual ICollection<Profile> Profiles { get; protected set; }

        protected Browser() { }

        public string GetProfileArgument(Profile profile)
        {
            var profileArgument = string.Empty;

            if (!string.IsNullOrEmpty(ProfileArgumentName))
            {
                profileArgument = $"{ProfileArgumentName}=\"{profile.Name}\"";
            }

            return profileArgument;
        }

        public void NavigateToUrl(string url, Profile profile)
        {
            var profileArgument = GetProfileArgument(profile);
            var urlArgument = $"\"{url}\"";
            var argumentList = new List<string>() { profileArgument, urlArgument };
            var arguments = string.Join(' ', argumentList);

            Process.Start(ExecutablePath, arguments);
        }
    }
}
