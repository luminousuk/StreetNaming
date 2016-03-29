using System;
using System.Collections.Generic;
using StreetNaming.DAL.DTO;
using StreetNaming.Domain.Models;
using StreetNaming.Util;

namespace StreetNaming.DAL.Mock
{
    public class MockStreetNamingRepository : IStreetNamingRepository
    {
        private const int MonthlyCaseMax = 20;

        private const int CashflowMax = 40000;

        private const int AllCasesCount = 100;

        private readonly Random _random = new Random();

        public int GetActiveCaseCount()
        {
            return _random.Next(100);
        }

        public int GetApplicantCount()
        {
            return _random.Next(100);
        }

        public int GetUnpaidTransactionCount()
        {
            return _random.Next(100);
        }

        public int GetCaseFollowUpCount()
        {
            return _random.Next(100);
        }

        public ICollection<MonthlyCaseCountDto> GetMonthlyCaseCount()
        {
            return new List<MonthlyCaseCountDto>
            {
                new MonthlyCaseCountDto
                {
                    Month = "Jan",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Feb",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Mar",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Apr",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "May",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Jun",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Jul",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Aug",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Sep",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Oct",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Nov",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Dec",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                }
            };
        }

        public ICollection<MonthlyCashflowDto> GetMonthlyCashflow()
        {
            return new List<MonthlyCashflowDto>
            {
                new MonthlyCashflowDto {Month = "Jan", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Feb", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Mar", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Apr", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "May", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Jun", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Jul", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Aug", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Sep", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Oct", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Nov", Income = 0.01M*_random.Next(CashflowMax)},
                new MonthlyCashflowDto {Month = "Dec", Income = 0.01M*_random.Next(CashflowMax)}
            };
        }

        public ICollection<Case> GetAllCases()
        {
            var cases = new List<Case>();
            for (var i = 0; i < AllCasesCount; i++)
            {
                cases.Add(GenerateCase());
            }

            return cases;
        }

        public ICollection<Case> GetActiveCases()
        {
            var cases = new List<Case>();
            for (var i = 0; i < AllCasesCount; i++)
            {
                cases.Add(GenerateCase(caseStatus: CaseStatus.Active));
            }

            return cases;
        }

        public ICollection<Case> GetCompletedCases()
        {
            var cases = new List<Case>();
            for (var i = 0; i < AllCasesCount; i++)
            {
                cases.Add(GenerateCase(caseStatus: CaseStatus.Completed));
            }

            return cases;
        }

        public Case GetCase(string reference)
        {
            return GenerateCase(reference);
        }

        public void UpdateCaseStatus(string reference, CaseStatus status)
        {
            // Do nothing
        }

        private Case GenerateCase(string reference = null, Applicant applicant = null, CaseStatus? caseStatus = null)
        {
            var newCase = new Case
            {
                CaseId = (_random.Next(100) + 123)*17,
                Reference = Guid.NewGuid(),
                Applicant = applicant ?? GenerateApplicant(),
                CaseStatus = caseStatus ?? (CaseStatus)(1<<_random.Next(0, 5)),
                CaseType = (_random.Next(2) == 1) ? CaseType.NewPropertyCase : CaseType.ExistingPropertyCase,
                IsRegisteredOwner = (_random.Next(10) > 0),
                ProposedAddress1 = Names.HouseNames[_random.Next(Names.HouseNames.Length)],
                ProposedAddress2 = (_random.Next(2) == 0) ? Names.HouseNames[_random.Next(Names.HouseNames.Length)] : null,
                EffectiveDate = (_random.Next(5) == 0) ? (DateTime?)DateTime.Today.AddDays(_random.Next(10, 60)) : null,
                AdditionalInformation = (_random.Next(3) == 0) ? Names.Lorem.Substring(0, _random.Next(Names.Lorem.Length)) : null,
                Attachments = new List<Attachment>(),
                CreatedDate = DateTime.Now.AddDays(_random.Next(365)*-1).AddHours(_random.Next(24)*-1),
                ModifiedDate = DateTime.Now
            };

            newCase.CustomerReference = reference ?? UniqueReferenceGenerator.GetCaseReference(newCase.CaseType == CaseType.ExistingPropertyCase ? "EP" : "NP", newCase.CaseId);
            newCase.ApplicantId = newCase.Applicant.ApplicantId;
            newCase.ProposedAddress3 = (newCase.ProposedAddress2 != null && _random.Next(2) == 0)
                ? Names.HouseNames[_random.Next(Names.HouseNames.Length)]
                : null;

            if (newCase.CaseType == CaseType.ExistingPropertyCase)
                newCase.ExistingPropertyUrn = (_random.Next() << 32) | _random.Next();

            for (var i = 0; i < _random.Next(4); i++)
            {
                var fileType = _random.Next(3);

                newCase.Attachments.Add(new Attachment
                {
                    AttachmentId = (_random.Next(100) + 19)*13,
                    Case = newCase,
                    CaseId = newCase.CaseId,
                    OriginalFileName = fileType == 0 ? $"attachment{i}.pdf" : fileType == 1 ? $"attachment{i}.jpg" : $"attachment{i}.docx",
                    ContentType = fileType == 0 ? "application/pdf" : fileType == 1 ? "image/jpeg" : "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    CreatedDate = newCase.CreatedDate,
                    ModifiedDate = DateTime.Now
                });
            }

            newCase.Signed = $"{newCase.Applicant.FirstName} {newCase.Applicant.LastName}";
            
            return newCase;
        }

        private Applicant GenerateApplicant()
        {
            var isMale = _random.Next(2) == 1;
            var applicant = new Applicant
            {
                ApplicantId = (_random.Next(100)+88)*27,
                Title = isMale ? "Mr" : "Mrs",
                FirstName = isMale
                    ? Names.FirstNamesMale[_random.Next(Names.FirstNamesMale.Length)]
                    : Names.FirstNamesFemale[_random.Next(Names.FirstNamesFemale.Length)],
                LastName = Names.Surnames[_random.Next(Names.Surnames.Length)],
                HouseNumber = _random.Next(100),
                Street = Names.StreetNames[_random.Next(Names.StreetNames.Length)],
                Town = Names.Towns[_random.Next(Names.Towns.Length)],
                County = "Somerset",
                PostCode = $"BA{_random.Next(1, 10)} {_random.Next(1, 10)}{(char)('A' + _random.Next(0, 26))}{(char)('A' + _random.Next(0, 26))}",
                Mobile = $"07{_random.Next(10)}{_random.Next(10)}{_random.Next(10)} {_random.Next(10)}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}",
                Telephone = $"01{_random.Next(10)}{_random.Next(10)}{_random.Next(10)} {_random.Next(10)}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            applicant.FullAddress = string.Join(", ", applicant.HouseNumber.ToString(), applicant.Street, applicant.Town,
                applicant.County, applicant.PostCode);
            applicant.Email = $"{applicant.FirstName.ToLower()}{applicant.LastName.ToLower()}@email.com";

            return applicant;
        }

        private static class Names
        {
            public static readonly string[] FirstNamesMale =
            {
                "Oliver", "Jack", "Harry", "Jacob", "Charlie", "Thomas", "George", "Oscar", "James", "William", "Noah",
                "Alfie", "Joshua", "Muhammad", "Henry", "Leo", "Archie", "Ethan", "Joseph", "Freddie", "Samuel",
                "Alexander", "Logan", "Daniel", "Isaac", "Max", "Mohammed", "Benjamin", "Mason", "Lucas", "Edward",
                "Harrison", "Jake", "Dylan", "Riley", "Finley", "Theo", "Sebastian", "Adam", "Zachary", "Arthur", "Toby",
                "Jayden", "Luke", "Harley", "Lewis", "Tyler", "Harvey", "Matthew", "David", "Reuben", "Michael",
                "Elijah", "Kian", "Tommy", "Mohammad", "Blake", "Luca", "Theodore", "Stanley", "Jenson", "Nathan",
                "Charles", "Frankie", "Jude", "Teddy", "Louie", "Louis", "Ryan", "Hugo", "Bobby", "Elliott", "Dexter",
                "Ollie", "Alex", "Liam", "Kai", "Gabriel", "Connor", "Aaron", "Frederick", "Callum", "Elliot", "Albert",
                "Leon", "Ronnie", "Rory", "Jamie", "Austin", "Seth", "Ibrahim", "Owen", "Caleb", "Ellis", "Sonny",
                "Robert", "Joey", "Felix", "Finlay", "Jackson"
            };

            public static readonly string[] FirstNamesFemale =
            {
                "Amelia", "Olivia", "Isla", "Emily", "Poppy", "Ava", "Isabella", "Jessica", "Lily", "Sophie", "Grace",
                "Sophia", "Mia", "Evie", "Ruby", "Ella", "Scarlett", "Isabelle", "Chloe", "Sienna", "Freya", "Phoebe",
                "Charlotte", "Daisy", "Alice", "Florence", "Eva", "Sofia", "Millie", "Lucy", "Evelyn", "Elsie", "Rosie",
                "Imogen", "Lola", "Matilda", "Elizabeth", "Layla", "Holly", "Lilly", "Molly", "Erin", "Ellie", "Maisie",
                "Maya", "Abigail", "Eliza", "Georgia", "Jasmine", "Esme", "Willow", "Bella", "Annabelle", "Ivy", "Amber",
                "Emilia", "Emma", "Summer", "Hannah", "Eleanor", "Harriet", "Rose", "Amelie", "Lexi", "Megan", "Gracie",
                "Zara", "Lacey", "Martha", "Anna", "Violet", "Darcey", "Maria", "Maryam", "Brooke", "Aisha", "Katie",
                "Leah", "Thea", "Darcie", "Hollie", "Amy", "Mollie", "Heidi", "Lottie", "Bethany", "Francesca", "Faith",
                "Harper", "Nancy", "Beatrice", "Isabel", "Darcy", "Lydia", "Sarah", "Sara", "Julia", "Victoria", "Zoe",
                "Robyn"
            };

            public static readonly string[] Surnames =
            {
                "Smith", "Jones", "Williams", "Taylor", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Johnson",
                "Roberts", "Robinson", "Thompson", "Wright", "Walker", "White", "Edwards", "Hughes", "Green", "Hall",
                "Lewis", "Harris", "Clarke", "Patel", "Jackson", "Wood", "Turner", "Martin", "Cooper", "Hill", "Ward",
                "Morris", "Moore", "Clark", "Lee", "King", "Baker", "Harrison", "Morgan", "Allen", "James", "Scott",
                "Phillips", "Watson", "Davis", "Parker", "Price", "Bennett", "Young", "Griffiths", "Mitchell", "Kelly",
                "Cook", "Carter", "Richardson", "Bailey", "Collins", "Bell", "Shaw", "Murphy", "Miller", "Cox",
                "Richards", "Khan", "Marshall", "Anderson", "Simpson", "Ellis", "Adams", "Singh", "Begum", "Wilkinson",
                "Foster", "Chapman", "Powell", "Webb", "Rogers", "Gray", "Mason", "Ali", "Hunt", "Hussain", "Campbell",
                "Matthews", "Owen", "Palmer", "Holmes", "Mills", "Barnes", "Knight", "Lloyd", "Butler", "Russell",
                "Barker", "Fisher", "Stevens", "Jenkins", "Murray", "Dixon", "Harvey"
            };

            public static readonly string[] StreetNames =
            {
                "High Street", "Station Road", "Main Street", "Park Road", "Church Road", "Church Street", "London Road",
                "Victoria Road", "Green Lane", "Manor Road", "Church Lane", "Park Avenue", "The Avenue", "The Crescent",
                "Queens Road", "New Road", "Grange Road", "Kings Road", "Kingsway", "Windsor Road", "Highfield Road",
                "Mill Lane", "Alexander Road", "York Road", "St. John’s Road", "Main Road", "Broadway", "King Street",
                "The Green", "Springfield Road", "George Street", "Park Lane", "Victoria Street", "Albert Road",
                "Queensway", "New Street", "Queen Street", "West Street", "North Street", "Manchester Road", "The Grove",
                "Richmond Road", "Grove Road", "South Street", "School Lane", "The Drive", "North Road", "Stanley Road",
                "Chester Road", "Mill Road"
            };

            public static readonly string[] Towns =
            {
                "Bath", "Bathampton", "Batheaston", "Bathford", "Bathwick", "Bishop Sutton", "Burnett", "Cameley",
                "Camerton", "Carlingcott", "Charlcombe", "Chelwood", "Chew Magna", "Chew Stoke", "Chewton Keynsham",
                "Claverton", "Claverton Down", "Clutton", "Combe Down", "Combe Hay", "Compton Dando", "Compton Martin",
                "Corston", "Dunkerton", "East Harptree", "Englishcombe", "Fairfield Park", "Farmborough",
                "Farrington Gurney", "Freshford", "Hallatrow", "High Littleton", "Hinton Blewett", "Hinton Charterhouse",
                "Hunstrete", "Inglesbatch", "Kelston", "Keynsham", "Kingsmead", "Kingsway", "Lambridge", "Langridge",
                "Lansdown", "Lower Swainswick", "Lyncombe Vale", "Marksbury", "Midford", "Midsomer Norton",
                "Monkton Combe", "Nempnett Thrubwell", "Newbridge", "Newton St Loe", "North Stoke", "Norton Malreward",
                "Odd Down", "Oldfield Park", "Paulton", "Peasedown St John", "Priston", "Publow", "Radstock",
                "St Catherine", "Saltford", "Shoscombe", "South Stoke", "Southdown", "Stanton Drew", "Stanton Prior",
                "Stony Littleton", "Stowey", "Stowey Sutton", "Swainswick", "Temple Cloud", "Timsbury", "Tunley",
                "Twerton", "Ubley", "Upper Swainswick", "Walcot", "Warleigh", "Wellow", "West Harptree", "Westmoreland",
                "Weston, Bath", "Whitchurch (Part only)", "Whiteway", "Widcombe", "Woollard", "Woolley"
            };

            public static readonly string[] HouseNames =
            {
                "Orchard", "Meadow", "Rose Cottage", "Holly", "Oak", "Willow", "School House", "The Willows",
                "Sunnyside", "Springfield", "Corner", "Highfield", "Old School", "Primrose", "Mill House",
                "The Old Rectory", "Yew Tree Cottage", "The Old Vicarage", "Oaklands", "The Old Post Office", "Lilac",
                "Honeysuckle", "Hillside", "Treetops", "Woodside", "The Old School House", "Ivy House", "Woodlands",
                "Red House", "White House", "Wayside", "Granary", "Lakeside", "Stables", "Toad Hall", "Haven",
                "Vicarage", "Fairview", "Laurels", "Thornfield", "Hillcrest", "The Barn", "Firs", "The Cottage", "Nook",
                "Coach House", "Clarence", "Beeches", "Highclere", "Gables"
            };

            public static readonly string Lorem =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.";
        }
    }
}