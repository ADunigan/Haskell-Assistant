using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Haskell_Atlanta_Types
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public bool Edit { get; set; }    
        public MenuItem Parent { get; set; }
        public ObservableCollection<MenuItem> Items { get; set; }
        //Item #, Description, Done?, Initials, Date, Punchlist Items
        public ObservableCollection<ChecklistItem> Checklist { get; set; }

        public MenuItem()
        {
            this.Title = "";
            this.Type = "";
            this.Edit = false;
            this.Items = new ObservableCollection<MenuItem>();            
            this.Checklist = new ObservableCollection<ChecklistItem>();
        }

        public MenuItem(string title)
        {
            this.Title = title;
            this.Type = "";
            this.Edit = false;
            this.Items = new ObservableCollection<MenuItem>();            
            this.Checklist = new ObservableCollection<ChecklistItem>();
        }

        public MenuItem GetParent()
        {
            return this.Parent;
        }
    }

    public class ChecklistItem : INotifyPropertyChanged
    {        
        private int numberValue;
        private string descriptionValue = String.Empty;
        private string initialsValue = String.Empty;
        private bool isdoneValue;
        private bool isdoneenabledValue = true;        
        private bool isNAValue;
        private bool isnaenabledValue = true;
        private string completeddateValue;
        private Punchlist punchlistValue;
        private bool punchliststatusValue = true;
        
        public int Number
        {
            get
            {
                return this.numberValue;
            }

            set
            {
                if(value != this.Number)
                {
                    this.numberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return this.descriptionValue;
            }

            set
            {
                if(value != this.Description)
                {
                    this.descriptionValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsDone
        {
            get
            {
                return this.isdoneValue;
            }

            set
            {
                if(value !=  this.IsDone)
                {
                    this.isdoneValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsDoneEnabled
        {
            get
            {
                return this.isdoneenabledValue;
            }

            set
            {
                if(value != this.IsDoneEnabled)
                {
                    this.isdoneenabledValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsNA
        {
            get
            {
                return this.isNAValue;
            }

            set
            {
                if(value != this.IsNA)
                {
                    this.isNAValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsNAEnabled
        {
            get
            {
                return this.isnaenabledValue;
            }

            set
            {
                if (value != this.IsNAEnabled)
                {
                    this.isnaenabledValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Initials
        {
            get
            {
                return this.initialsValue;
            }

            set
            {
                if(value != this.Initials)
                {
                    this.initialsValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CompletedDate
        {
            get
            {
                return this.completeddateValue;
            }

            set
            {
                if(value != this.CompletedDate)
                {
                    this.completeddateValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Punchlist Punchlist
        {
            get
            {
                return this.punchlistValue;
            }

            set
            {
                if(value != this.Punchlist)
                {
                    this.punchlistValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool PunchlistStatus
        {
            get
            {
                return this.punchliststatusValue;
            }

            set
            {
                if(value != this.PunchlistStatus)
                {
                    this.punchliststatusValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ChecklistItem()
        {            
            this.Description = "";
            this.IsDone = false;
            this.Initials = "";
            this.Punchlist = new Punchlist();
            this.PunchlistStatus = false;
        }

        public ChecklistItem(string description)
        {
            this.Description = description;
            this.IsDone = false;
            this.Initials = "";
            this.Punchlist = new Punchlist();
            this.PunchlistStatus = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class Punchlist
    {
        //Item #, Description, Done?, Company, Person Responsible, Estimated Date, Completion Date
        public ObservableCollection<PunchlistItem> PunchlistItems { get; set; }

        public Punchlist()
        {
            this.PunchlistItems = new ObservableCollection<PunchlistItem>();
        }
    }

    public class PunchlistItem : INotifyPropertyChanged
    {
        private int numberValue;
        private string descriptionValue = String.Empty;
        private bool isdoneValue;
        private string companyValue = String.Empty;
        private string responsibleValue = String.Empty;
        private string estimateddateValue = String.Empty;
        private string completeddateValue = String.Empty;

        public int Number
        {
            get
            {
                return this.numberValue;
            }

            set
            {
                if(value != this.numberValue)
                {
                    this.numberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return this.descriptionValue;
            }

            set
            {
                if(value != this.descriptionValue)
                {
                    this.descriptionValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsDone
        {
            get
            {
                return this.isdoneValue;
            }

            set
            {
                if(value != this.isdoneValue)
                {
                    this.isdoneValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Company
        {
            get
            {
                return this.companyValue;
            }

            set
            {
                if(value != this.companyValue)
                {
                    this.companyValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Responsible
        {
            get
            {
                return this.responsibleValue;
            }

            set
            {
                if(value != this.responsibleValue)
                {
                    this.responsibleValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string EstimatedDate
        {
            get
            {
                return this.estimateddateValue;
            }

            set
            {
                if(value != this.estimateddateValue)
                {
                    this.estimateddateValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CompletedDate
        {
            get
            {
                return this.completeddateValue;
            }

            set
            {
                if(value != this.completeddateValue)
                {
                    this.completeddateValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public PunchlistItem()
        {
            this.Description = "";
            this.IsDone = false;
            this.Company = "";
            this.Responsible = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class TemplateItem : INotifyPropertyChanged
    {
        private string typeValue;
        private string titleValue;
        private ObservableCollection<ChecklistItem> checklistValue;

        public string Type
        {
            get
            {
                return this.typeValue;
            }

            set
            {
                if(value != this.typeValue)
                {
                    this.typeValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Title
        {
            get
            {
                return this.titleValue;
            }

            set
            {
                if(value != this.titleValue)
                {
                    this.titleValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<ChecklistItem> Checklist
        {
            get
            {
                return this.checklistValue;
            }

            set
            {
                if(value != this.checklistValue)
                {
                    this.checklistValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TemplateItem()
        {
            this.Type = "";
            this.Title = "";
            this.Checklist = new ObservableCollection<ChecklistItem>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
