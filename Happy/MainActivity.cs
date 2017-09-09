using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;

namespace Happy
{
    [Activity(Label = "Happy", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {
        //The motivation of this app is to fight the depression epedemic
        TextView quoteView;

        string[] hQuotes;
        string[] mQuotes;
        string[] iQuotes;
        
        int hQuoteIndex = 0;
        int mQuoteIndex = 0;
        int iQuoteIndex = 0;
        int selectedTab = 0;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            //this randomizes the strings for the quotes
            setUpStringArray();
            //this sets all of the views
            assignViews();
            //This creates the tabs
            SetUpApp();
           
            //this sets it to happy
            selectedTab = 0;
            SwitchTabs(selectedTab);



            
        }
        private void assignViews()
        {
            quoteView = (TextView)FindViewById(Resource.Id.quoteView);
            quoteView.Click += delegate { NextQuote(); };
        }
        private void setUpStringArray()
        {
            //assigns strigns to quotes array
            hQuotes = new string[] { "hello", "help", "here", "h", "he", "g", "golo" };
            iQuotes = new string[] { "z", "x", "c", "h", "v", "b", "n" };
            mQuotes = new string[] { "a", "s", "d", "f", "g", "h", "j" };
            //sorts the quotes strings randomly so not always seeing same quotes
            Random rnd = new Random();
            hQuotes = hQuotes.OrderBy(x => rnd.Next()).ToArray();
            iQuotes = iQuotes.OrderBy(x => rnd.Next()).ToArray();
            mQuotes = mQuotes.OrderBy(x => rnd.Next()).ToArray();
        }
        private void SetUpApp()
        {
            //below creates the tabs for the homepage and sets them up to do something when they switch
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText("Happy");
            tab.TabSelected += (sender, args) => {
                // Do something when tab is selected
                selectedTab = 0;
                SwitchTabs(selectedTab);

            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Inspiration");
            tab.TabSelected += (sender, args) =>
            {
                // Do something when tab is selected
                selectedTab = 1;
                SwitchTabs(selectedTab);

            };
            ActionBar.AddTab(tab);

            tab = ActionBar.NewTab();
            tab.SetText("Motivation");
            tab.TabSelected += (sender, args) =>
            {
                // Do something when tab is selected
                selectedTab = 2;
                SwitchTabs(selectedTab);

            };
            ActionBar.AddTab(tab);
        }
        private void SwitchTabs(int tab)
        {
            //this needs to be switch no matter what so call no matter what
            NextQuote();
            switch (tab)
            {
                //the switch is to switch the other views to visible/invisible after switching
                case 0:
                    
                    break;
                case 1:
                    break;
                case 2:
                    break;

            }
        }
        private void NextQuote()
        {

            switch (selectedTab)
            {
                case 0:
                    hQuoteIndex += 1;
                    if (hQuoteIndex == hQuotes.Length)
                    {
                        hQuoteIndex = 0;
                    }
                    quoteView.Text = hQuotes[hQuoteIndex];
                    break;
                case 1:
                    iQuoteIndex += 1;
                    if (iQuoteIndex == iQuotes.Length)
                    {
                        iQuoteIndex = 0;
                    }
                    quoteView.Text = iQuotes[iQuoteIndex];
                    break;
                case 2:
                    mQuoteIndex += 1;
                    if (mQuoteIndex == mQuotes.Length)
                    {
                        mQuoteIndex = 0;
                    }
                    quoteView.Text = mQuotes[mQuoteIndex];
                    break;
                
            }
            
                
        }
    }
}

