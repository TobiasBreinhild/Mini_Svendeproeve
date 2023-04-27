using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SamleProgram
{
    /// <summary>
    /// Interaction logic for CollectionPage.xaml
    /// </summary>
    public partial class CollectionPage : Page
    {
        private static LoginPage loginNavigate = new LoginPage();
        public CollectionPage()
        {
            InitializeComponent();
            AddDummyData();
            AddLists();
        }

        public List<Collection> collections = new List<Collection>();
        public List<Object> objects = new List<Object>();

        public int currentCollectionId;

        public void AddDummyData()
        {
            collections.Add(new Collection(1, "Playing Cards", false));
            collections.Add(new Collection(2, "Bottle Caps", true));
            collections.Add(new Collection(3, "Books - Harry Potter", true));

            objects.Add(new Object(1, 1, "8 of Diamonds", true));
            objects.Add(new Object(2, 1, "2 of Hearts", true));
            objects.Add(new Object(3, 1, "3 of Clubs", true));
            objects.Add(new Object(4, 1, "10 of Spades", true));
            objects.Add(new Object(5, 1, "King of Hearts", false));

            objects.Add(new Object(6, 2, "Coca Cola", true));
            objects.Add(new Object(7, 2, "Fanta", false));
            objects.Add(new Object(8, 2, "Sprite", true));
            objects.Add(new Object(9, 2, "Pepsi", false));

            objects.Add(new Object(10, 3, "Book 1", false));
            objects.Add(new Object(11, 3, "Book 2", false));
            objects.Add(new Object(12, 3, "Book 3", false));
            objects.Add(new Object(13, 3, "Book 4", false));
            objects.Add(new Object(14, 3, "Book 5", false));
            objects.Add(new Object(15, 3, "Book 6", false));
        }

        public void AddLists()
        {
            if(collections.Count == 0)
            {
                NoCollectionsLabel.Visibility = Visibility.Visible;
                CollectionsView.Visibility = Visibility.Collapsed;
            }
            else if(collections.Count > 0)
            {
                CollectionsViewStack.Children.Clear();
                NoCollectionsLabel.Visibility = Visibility.Collapsed;
                CollectionsView.Visibility = Visibility.Visible;

                foreach (Collection collection in collections)
                {
                    StackPanel stack = new StackPanel();
                    stack.Orientation = Orientation.Horizontal;
                    stack.Height = 300;
                    stack.MaxWidth = 1000;

                    Border borderImage = new Border();
                    borderImage.Height = stack.Height;
                    borderImage.Width = stack.Height;
                    borderImage.CornerRadius = new CornerRadius(25);
                    borderImage.Background = Brushes.DarkGray;
                    borderImage.BorderBrush = Brushes.White;
                    borderImage.BorderThickness = new Thickness(5);

                    Button button = new Button();
                    button.Height = stack.Height;
                    button.MaxWidth = 1000;
                    button.Content = collection._name;
                    button.FontSize = 40;
                    button.Foreground = Brushes.White;
                    button.Background = Brushes.Transparent;
                    button.BorderBrush = Brushes.Transparent;
                    button.Click += ViewCollection_Click;

                    Border borderButton = new Border();
                    borderButton.Height = stack.Height;
                    borderButton.Width = 500;
                    borderButton.CornerRadius = new CornerRadius(25);
                    borderButton.Background = Brushes.DarkGray;
                    borderButton.BorderBrush = Brushes.White;
                    borderButton.BorderThickness = new Thickness(5);
                    borderButton.Child = button;

                    stack.Children.Add(borderImage);
                    stack.Children.Add(borderButton);
                    CollectionsViewStack.Children.Add(stack);
                }
            }
            
        }

        public void AddPublishedLists()
        {
            if (collections.Count == 0)
            {
                NoPublicCollectionsLabel.Visibility = Visibility.Visible;
                PublishedCollectionsView.Visibility = Visibility.Collapsed;
            }
            else if (collections.Count > 0)
            {
                NoPublicCollectionsLabel.Visibility = Visibility.Collapsed;
                PublishedCollectionsView.Visibility = Visibility.Visible;

                PublishedCollectionsViewStack.Children.Clear();

                foreach (Collection collection in collections)
                {
                    if (collection._status == true)
                    {
                        StackPanel stack = new StackPanel();
                        stack.Orientation = Orientation.Horizontal;
                        stack.Height = 300;
                        stack.MaxWidth = 1000;

                        Border borderImage = new Border();
                        borderImage.Height = stack.Height;
                        borderImage.Width = stack.Height;
                        borderImage.CornerRadius = new CornerRadius(25);
                        borderImage.Background = Brushes.DarkGray;
                        borderImage.BorderBrush = Brushes.White;
                        borderImage.BorderThickness = new Thickness(5);

                        Button button = new Button();
                        button.Height = stack.Height;
                        button.MaxWidth = 1000;
                        button.Content = collection._name;
                        button.FontSize = 40;
                        button.Foreground = Brushes.White;
                        button.Background = Brushes.Transparent;
                        button.BorderBrush = Brushes.Transparent;

                        Border borderButton = new Border();
                        borderButton.Height = stack.Height;
                        borderButton.Width = 500;
                        borderButton.CornerRadius = new CornerRadius(25);
                        borderButton.Background = Brushes.DarkGray;
                        borderButton.BorderBrush = Brushes.White;
                        borderButton.BorderThickness = new Thickness(5);
                        borderButton.Child = button;

                        stack.Children.Add(borderImage);
                        stack.Children.Add(borderButton);
                        PublishedCollectionsViewStack.Children.Add(stack);
                    }
                }
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MyPageGrid.Visibility = Visibility.Visible;
            SelectedCollectionGrid.Visibility = Visibility.Collapsed;
            OtherCollectionsGrid.Visibility = Visibility.Collapsed;
            CreateAddLabel.Content = "Create collection";
            CreateAddButton.Click -= PublishACollection_Click;
            CreateAddButton.Click -= AddObjectToCollection_Click;
            CreateAddButton.Click += CreateCollection_Click;

            NavigationService.Navigate(loginNavigate);
        }

        private void MyPageButton_Click(object sender, RoutedEventArgs e)
        {
            MyPageGrid.Visibility = Visibility.Visible;
            SelectedCollectionGrid.Visibility = Visibility.Collapsed;
            OtherCollectionsGrid.Visibility = Visibility.Collapsed;
            GoBackButtonBorder.Visibility = Visibility.Collapsed;
            CreateAddLabel.Content = "Create collection";
            CreateAddButton.Click -= PublishACollection_Click;
            CreateAddButton.Click -= AddObjectToCollection_Click;
            CreateAddButton.Click += CreateCollection_Click;
        }

        private void OtherCollectionsButton_Click(object sender, RoutedEventArgs e)
        {
            AddPublishedLists();
            //PublishedCollectionsView.Visibility = Visibility.Visible;
            MyPageGrid.Visibility = Visibility.Collapsed;
            SelectedCollectionGrid.Visibility = Visibility.Collapsed;
            OtherCollectionsGrid.Visibility = Visibility.Visible;
            GoBackButtonBorder.Visibility = Visibility.Collapsed;
            CreateAddLabel.Content = "Publish collection";
            CreateAddButton.Click -= CreateCollection_Click;
            CreateAddButton.Click -= AddObjectToCollection_Click;
            CreateAddButton.Click += PublishACollection_Click;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MyPageGrid.Visibility = Visibility.Visible;
            SelectedCollectionGrid.Visibility = Visibility.Collapsed;
            GoBackButtonBorder.Visibility = Visibility.Collapsed;
            CreateAddLabel.Content = "Create collection";
            CreateAddButton.Click -= PublishACollection_Click;
            CreateAddButton.Click -= AddObjectToCollection_Click;
            CreateAddButton.Click += CreateCollection_Click;
        }

        private void ViewCollection_Click(object sender, RoutedEventArgs e)
        {
            MyPageGrid.Visibility = Visibility.Collapsed;
            SelectedCollectionGrid.Visibility = Visibility.Visible;
            OtherCollectionsGrid.Visibility = Visibility.Collapsed;
            GoBackButtonBorder.Visibility = Visibility.Visible;
            CreateAddLabel.Content = "Add object";
            CreateAddButton.Click -= CreateCollection_Click;
            CreateAddButton.Click -= PublishACollection_Click;
            CreateAddButton.Click += AddObjectToCollection_Click;
        }

        private void CreateCollection_Click(object sender, RoutedEventArgs e)
        {
            CreateCollectionBorder.Visibility = Visibility.Visible;
        }

        private void AddObjectToCollection_Click(object sender, RoutedEventArgs e)
        {
            AddToCollectionBorder.Visibility = Visibility.Visible;
        }

        private void PublishACollection_Click(object sender, RoutedEventArgs e)
        {
            CollectionsDropDown.Items.Clear();
            PublishCollectionBorder.Visibility = Visibility.Visible;
            foreach(Collection collection in collections)
            {
                if(collection._status == false)
                {
                    CollectionsDropDown.Items.Add(collection._name);
                }
            }
        }

        private void CreateNewCollection_Click(object sender, RoutedEventArgs e)
        {
            if(collections.Count == 0)
            {
                collections.Add(new Collection(1, CollectionNameBox.Text, false));
                CreateCollectionBorder.Visibility = Visibility.Collapsed;
                AddLists();
            }
            else
            {
                collections.Add(new Collection(collections.Count + 1, CollectionNameBox.Text, false));
                CreateCollectionBorder.Visibility = Visibility.Collapsed;
                AddLists();
            }
        }

        private void AddToCollection_Click(object sender, RoutedEventArgs e)
        {
            // Kunne ikke finde en måde at sende en værdi med til at tjekke hvilken collection man er på
        }

        private void PublishCollection_Click(object sender, RoutedEventArgs e)
        {
            foreach(Collection collection in collections)
            {
                if(collection._name == CollectionsDropDown.SelectedItem.ToString())
                {
                    collection._status = true;
                }
            }
            PublishCollectionBorder.Visibility = Visibility.Collapsed;
            AddPublishedLists();
        }

        private void CreateCollectionBackButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCollectionBorder.Visibility = Visibility.Collapsed;
            CollectionNameBox.Text = "";
        }

        private void AddToCollectionBackButton_Click(object sender, RoutedEventArgs e)
        {
            AddToCollectionBorder.Visibility = Visibility.Collapsed;
            ObjectNameBox.Text = "";
        }

        private void PublishCollectionBackButton_Click(object sender, RoutedEventArgs e)
        {
            PublishCollectionBorder.Visibility = Visibility.Collapsed;
        }
    }
}
