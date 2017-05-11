using System;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class StringAlgorithmsDemo : Window
    {
        StringAlgorithms StringAlgorithmsObject = new StringAlgorithms();

        //int resultIndex = -1;
        public StringAlgorithmsDemo()
        {
            InitializeComponent();
        }

        private void BruteForceSearchsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            StringAlgorithmsObject.BruteForceOrNaiveSearchDemo();
        }

        private void BoyerMooreDemoButton_Click(object sender, RoutedEventArgs e)
        {
//            StringAlgorithmsObject.RunBoyerMooreSearchDemo();
        }
        private void BoyerMooreHorspoolDemoButton_Click(object sender, RoutedEventArgs e)
        {
//            StringAlgorithmsObject.RunBoyerMooreHorspoolSearchDemo();
        }

        private void ReverseWrodsInStringDemoButton_Click(object sender, RoutedEventArgs e)
        {
            StringAlgorithms.LongestSubStringWithoutRepeatingCharacters();
            StringAlgorithms.ReverseWordsInString();
        }

        private void PermutationCombinationsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            StringAlgorithms.StringPermutationsTest();
        }

        private void KMPDemoButton_Click(object sender, RoutedEventArgs e)
        {
            StringAlgorithms.RunKnuthMorrisPrattSearchDemo();
        }

        private void IsPalindromeDemoButton_Click(object sender, RoutedEventArgs e)
        {
            string str = "123454321";

            bool result = StringAlgorithms.IsPalindromeString(str);
            MessageBox.Show("Is given string  '" + str + "' is Palindrome " + result);
        }

        private void BracesValidationDemoButton_Click(object sender, RoutedEventArgs e)
        {
            StringAlgorithmsObject.AreParenthesesBalancedTest();
        }

        private void BracesPermutationsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            StringAlgorithmsObject.BracketPermutationsTest();
        }

        private void MultipleProgramsDemoButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = StringAlgorithmsObject.HasPermutations("eidbaooo", "ab");
            //Console.WriteLine("Source String " )
            Console.WriteLine("Result " + result);
        }
    }
}
