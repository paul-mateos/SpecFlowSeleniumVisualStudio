using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.Commons
{
    public class Table
    {
        private IWebElement element;

        public Table(IWebElement element)
        {
            this.element = element;
        }

        public string GetCellValue(string lookupColumn, string lookupValue, string returnColumn)
        {
            //if (!this.element.Text.Contains("records are available in this view.")) //No Records are available
            //{
                int lookupColumnIndex = this.GetColumnIndex(lookupColumn);
                int returnColumnIndex = this.GetColumnIndex(returnColumn);

                IReadOnlyCollection<IWebElement> rows = this.element.FindElements(By.CssSelector("tbody tr"));
                foreach (IWebElement row in rows)
                {
                    if (row.Text != "")
                    {
                        IReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                        if (cells.ElementAt(lookupColumnIndex).Text == lookupValue)
                        {
                            return cells.ElementAt(returnColumnIndex).Text;
                        }
                    }
                }
            //}
            //else
            //{
            //    throw new Exception(String.Format("Unable to find record"));
            //}
            throw new Exception(String.Format("Unable to find table row {0} with value {1}", lookupColumn, lookupValue));
        }

        public void ClickCellValue(string lookupColumn, string lookupValue, string returnColumn)
        {
            //if (!this.element.Text.Contains("records are available in this view.")) //No Records are available
            //{
            int lookupColumnIndex = this.GetColumnIndex(lookupColumn);
            int returnColumnIndex = this.GetColumnIndex(returnColumn);

            IReadOnlyCollection<IWebElement> rows = this.element.FindElements(By.CssSelector("tbody tr"));
            foreach (IWebElement row in rows)
            {
                if (row.Text != "")
                {
                    IReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                    if (cells.ElementAt(lookupColumnIndex).Text == lookupValue)
                    {
                        cells.ElementAt(returnColumnIndex).Click();
                    }
                }
            }
            //}
            //else
            //{
            //    throw new Exception(String.Format("Unable to find record"));
            //}
            throw new Exception(String.Format("Unable to find table row {0} with value {1}", lookupColumn, lookupValue));
        }


        private int GetColumnIndex(string lookupColumn)
        {
            IReadOnlyCollection<IWebElement> headerCells = this.element.FindElements(By.CssSelector("thead tr th"));

            for (int i = 0; i < headerCells.Count; i++)
            {
                string text = headerCells.ElementAt(i).Text;

                if (text.Equals(lookupColumn))
                {
                    return i;
                }
            }
            throw new Exception("Unable to find column " + lookupColumn);
        }

        public int GetRowCount()
        {
            IReadOnlyCollection<IWebElement> rows = this.element.FindElements(By.CssSelector("tbody tr"));

            foreach (IWebElement row in rows)
            {
                if (row.Text != "")
                {
                    IWebElement data = row.FindElement(By.CssSelector("td"));
                    if (data.GetAttribute("innerHTML").Contains("No") && data.GetAttribute("innerHTML").Contains("records are available"))
                    {
                        return 0;
                    }
                }

            }
            return rows.Count;
        }

        public bool GetNoRecordsInTable()
        {

            IWebElement noRecords = this.element.FindElement(By.CssSelector("tbody tr td"));

            if (noRecords.GetAttribute("innerHTML").Contains("No"))
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public int GetColumnHeaderIndex(string ColumnName)
        {
            IReadOnlyCollection<IWebElement> headers = this.element.FindElements(By.CssSelector("tbody tr th"));
            int headerCount = headers.Count;
            int currentCount = 0;

            foreach (IWebElement header in headers)
            {
                currentCount += 1;
                if (header.GetAttribute("displaylabel") == ColumnName)
                {
                    return currentCount;
                }
            }
            return 0; // If specified column not found return 0
        }
    }
}