# Portfolio Web App

Web Project that serves my Portfolio API.

## Technologies

- .NET 8 Blazor
- WebApi
- NSubstitute (Unit Testing)


## API

API will return JSON Objects from the [API Data Storage](https://github.com/Ashley-Gibson/portfolio-web/blob/main/Portfolio%20WebAPI%20Design%20Document.md#api-data-storage "API Data Storage").

#### Controllers

- Projects
- Experience
- Education
- Certifications
- MyLinks

#### Projects Controller

- Gets a list of all my current Portfolio Projects (public only from GitHub)
- Each PortfolioProject Item returns:
    - Project Title
    - Project Description
    - Project Image/Gif
    - Statistics on contributions etc

#### Experience Controller

- Gets a list of past Work Experience
- Each ExperienceRow returns:
    - Employer Name
    - Start Date
    - End Date
    - Employer Website Link
    - Employer Logo
    - Length of service
    - Technologies used/Skills Gained
    - Projects worked on

#### Education Controller

- Gets a list of past Education Institutions
- Each EducationRow returns:
    - Institution Name
    - Enrollment Date
    - Graduation Date
    - List of courses/grades
    - Extra-curricular activities

#### Certifications Controller

- Gets a list of past Certifications
- Each Certfication returns:
    - Certification Name
    - Date Completed
    - Expiry Date
    - Skills

#### MyLinks Controller

- Returns a list of my links (Social Media, Professional links, Email etc)
- Each link returns:
    - Link Name
    - Link Value
    - Link Icon


## Web

#### Navigation Sidebar

Utilises built-in .NET/Bootstrap sidebar navigation.

#### Homepage

Replica of current/old Personal Website page - utilises MyLinks Controller for Links

#### Portfolio Projects Page

Utilises PortfolioProjects Controller.

List of all Projects in a table. Clicking on a Project shows a popup with info about the Project.

#### Experience Page

Utilises Experience Controller.

List of all previous Employers in a table. Clicking on an ExperienceRow shows a popup with info about the Employer and my experience.

#### Education Page

Utilises Education Controller.

List of all previous Education Institutions in a table. Clicking on an Institution shows a popup with info about the Institution and my degree.

#### Certifications Page

Utilises Certifications Controller.

List of all Certifications gained in a table. Clicking on a Certification shows a popup with info about the Certification and knowledge learnt.

Could link this to the Previous Employers functionality if certifications were gained from an employer instead of my own free time?


## API Data Storage

All endpoints return JSON objects.

Data is stored originally in a set of CSVs. Later this will be integrated into an Azure SQL Database to store properly.

#### Projects CSV/Table

- Name: STRING
- Description: STRING
- Image: STRING
- ContributionsThisYear: INT
- ContributionsThisWeek: INT
- ContributionsThisMonth: INT

#### Experience CSV/Table

- EmployerName: STRING NULL
- StartDate: DATETIME
- EndDate: DATETIME
- WebsiteLink: STRING
- Image: STRING
- LengthOfServiceMonths: INT
- TechnologiesUsed: STRING (Semi Colon separated list)
- SkillsGained: STRING (Semi Colon separated list)
- Projects: STRING (Semi Colon separated list)

#### Education CSV/Table

- InstitutionName: STRING NULL
- DateEnrolled: DATETIME
- DateGraduated: DATETIME
- CourseGrades: STRING (Semi Colon separated list, Hyphen separating Course-Grade)
- ExtraCurricularActivities: STRING (Semi Colon separated list)

#### Certifications CSV/Table

- CertificationName: STRING
- DateCompleted: DATETIME
- ExpiryDate: DATETIME
- Skills: STRING (Semi Colon separated list)

#### MyLinks CSV/Table

- Name: STRING
- Value: STRING
- Image: STRING
