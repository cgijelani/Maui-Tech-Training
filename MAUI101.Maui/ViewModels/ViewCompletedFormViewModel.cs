using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI101.Maui.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.ViewModels
{
	[QueryProperty("FormDetails", "formDetails")]
	public partial class ViewCompletedFormViewModel : ObservableObject
	{
		public ViewCompletedFormViewModel()
        {
            
        }

        [ObservableProperty]
        AdoptionForm formDetails;
    }
}
