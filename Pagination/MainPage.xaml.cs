using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pagination
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<String> myList;
        //define how many pages totally accroding to calculation.
        int pageCount;
        //define current page number.
        int currentPage;
        //define how many items you want to show in page.
        int countPerPage;
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            myList = new List<string>();
            for (int i = 0; i < 101; i++)
            {
                myList.Add("Item " + i);
            }

            countPerPage = 10;
            float tmpFloat = (float)myList.Count / countPerPage;
            pageCount = (int)Math.Ceiling(tmpFloat);
            currentPage = 1;
            ManageButton();
            myDataGrid.ItemsSource = myList.GetRange(0, countPerPage);
            base.OnNavigatedTo(e);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            ManageButton();
            myDataGrid.ItemsSource = GetList(myList);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            ManageButton();
            myDataGrid.ItemsSource = GetList(myList);
        }

        private void ManageButton()
        {
            if (currentPage <= 1)
            {
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = true;
            }
            else if (currentPage >= pageCount)
            {
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = false;
            }
            else
            {
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
            }
        }


        private List<String> GetList(List<String> sourceList)
        {
            int index = (currentPage - 1) * countPerPage;
            int countsToShow;
            if (currentPage == pageCount)
            {
                countsToShow = myList.Count - (currentPage - 1) * countPerPage;
            }
            else
            {
                countsToShow = countPerPage;
            }
            return sourceList.GetRange(index, countsToShow);
        }
    }
}
