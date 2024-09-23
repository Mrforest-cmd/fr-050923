using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Globalization;

namespace _19._09._24WPF
{
    public partial class CalendarWindow : Window
    {
        private Dictionary<DateTime, List<string>> events;
        private DateTime currentMonth;
        private DateTime? selectedDate;

        public CalendarWindow()
        {
            InitializeComponent();
            events = new Dictionary<DateTime, List<string>>();
            currentMonth = DateTime.Today;
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            monthYearText.Text = currentMonth.ToString("MMMM yyyy");
            calendarGrid.Children.Clear();

            DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);

            int dayOfWeek = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            for (int i = 0; i < daysInMonth; i++)
            {
                Button dayButton = new Button
                {
                    Content = (i + 1).ToString(),
                    Tag = new DateTime(currentMonth.Year, currentMonth.Month, i + 1)
                };
                dayButton.Click += DayButton_Click;

                if (events.ContainsKey((DateTime)dayButton.Tag))
                {
                    dayButton.Background = Brushes.LightBlue;
                }

                if (((DateTime)dayButton.Tag).Date == DateTime.Today)
                {
                    dayButton.BorderBrush = Brushes.Red;
                    dayButton.BorderThickness = new Thickness(2);
                }

                Grid.SetRow(dayButton, (i + dayOfWeek) / 7);
                Grid.SetColumn(dayButton, (i + dayOfWeek) % 7);
                calendarGrid.Children.Add(dayButton);
            }

            if (DateTime.IsLeapYear(currentMonth.Year))
            {
                TextBlock leapYearIndicator = new TextBlock
                {
                    Text = "Високосный год",
                    Foreground = Brushes.Green,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom
                };
                Grid.SetRow(leapYearIndicator, 6);
                Grid.SetColumnSpan(leapYearIndicator, 7);
                calendarGrid.Children.Add(leapYearIndicator);
            }
        }

        private void DayButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            selectedDate = (DateTime)clickedButton.Tag;
            selectedDateText.Text = selectedDate.Value.ToShortDateString();
            UpdateEventsList();
        }

        private void UpdateEventsList()
        {
            eventsListBox.Items.Clear();
            if (selectedDate.HasValue && events.ContainsKey(selectedDate.Value))
            {
                foreach (string eventText in events[selectedDate.Value])
                {
                    eventsListBox.Items.Add(eventText);
                }
            }
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDate.HasValue && !string.IsNullOrWhiteSpace(newEventTextBox.Text))
            {
                if (!events.ContainsKey(selectedDate.Value))
                {
                    events[selectedDate.Value] = new List<string>();
                }
                events[selectedDate.Value].Add(newEventTextBox.Text);
                UpdateEventsList();
                UpdateCalendar();
                newEventTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите дату и введите текст события.");
            }
        }

        private void PreviousMonth_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            UpdateCalendar();
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            UpdateCalendar();
        }
    }
}