﻿using Burls.Application.Browsers.State;
using Burls.Application.Profiles.Commands;
using Burls.Domain;
using Burls.Windows.Constants;
using Burls.Windows.Services;
using MediatR;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Burls.Windows.ViewModels
{
    public class BrowserProfileSetupViewModel : BindableBase
    {
        private readonly IMediator _mediator;
        private readonly IBrowserState _browserState;

        public IEnumerable<BrowserProfile> BrowserProfiles => _browserState.BrowserProfiles;
        public IList<SelectionRule> SelectionRules => SelectedBrowserProfile?.Profile?.SelectionRules;

        public BrowserProfile SelectedBrowserProfile
        {
            get { return _browserState.SelectedBrowserProfile; }
            set { _browserState.SelectedBrowserProfile = value; }
        }
        public SelectionRule SelectedSelectionRule
        {
            get { return _browserState.SelectedSelectionRule; }
            set { _browserState.SelectedSelectionRule = value; }
        }

        public ICommand AddSelectionRuleCommand { get; set; }
        public ICommand RemoveSelectionRuleCommand { get; set; }

        public BrowserProfileSetupViewModel(IMediator mediator, IBrowserState browserState)
        {
            _mediator = mediator;
            _browserState = browserState;

            _browserState.StateChanged += _browserState_StateChanged;

            AddSelectionRuleCommand = new DelegateCommand(async () => await AddSelectionRuleAsync());
            RemoveSelectionRuleCommand = new DelegateCommand(async () => await RemoveSelectionRuleAsync());
        }

        private void _browserState_StateChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged(nameof(BrowserProfiles));
            RaisePropertyChanged(nameof(SelectionRules));
            RaisePropertyChanged(nameof(SelectedBrowserProfile));
            RaisePropertyChanged(nameof(SelectedSelectionRule));
        }

        private Task AddSelectionRuleAsync()
        {
            //Websites.Add(new Website(""));
            //RaisePropertyChanged(nameof(SelectedBrowserProfile));
            //RaisePropertyChanged(nameof(Websites));

            return Task.CompletedTask;
        }

        private async Task RemoveSelectionRuleAsync()
        {
            var command = new DeleteProfileSelectionRuleCommand(
                _browserState.SelectedBrowserProfile.Profile.Id,
                _browserState.SelectedSelectionRule.Id);

            await _mediator.Send(command);
        }
    }
}
