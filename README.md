**Initialization**

Before you can make requests to the State Duma API, you need to setup it.
The following information is required :

1. _APPKey_ and/or _APIKey_ which you can acquire them here - [http://api.duma.gov.ru/pages/dokumentatsiya/obrashchenie-k-api](http://api.duma.gov.ru/pages/dokumentatsiya/obrashchenie-k-api)

2. Data exchange format to use (XML/JSON).


Example (initialize API, using values of API/APP key stored inside application configuration file): 

`IApiCaller caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));`

***

Supported set of operations:

***

**Topics**

_Description:_ Returns list of topics (subject units).

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov)

_Code:_ 

`IApiCaller caller = ...`

`IEnumerable<Topic> topics = caller.Topics();`

***

**Law Branches**

_Description:_ Returns list of laws branches.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<LawBranch> branches = caller.Branches();`

***

**Deputies**

_Description:_ Returns list of deputies of the State Duma and members of the Federation Council.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<Deputy> deputies = caller.Deputies();`

IEnumerable<Deputy> deputies = caller.Deputies(x=> x.Position(DeputyPosition.DumaDeputy).Current(false).Name("А"));

***

**Committees**

_Description:_ Returns list of committees.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<Committee> committees = caller.Committees();`

***

**Regional Authorities**

_Description:_ Returns list of regional law authorities.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<RegionalAuthority> authorities = caller.RegionalAuthorities();`

`IEnumerable<RegionalAuthority> authorities = caller.RegionalAuthorities(x => x.Current(false));`

***

**Federal Authorities**

_Description:_ Returns list of federal law authorities.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<FederalAuthority> authorities = caller.FederalAuthorities();`

`IEnumerable<FederalAuthority> authorities = caller.FederalAuthorities(x => x.Current());`

***

**Law Stages**

_Description:_ Returns list of laws review stages.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<LawStage> stages = caller.Stages();`

***

**Instances**

_Description:_ Returns list of instances.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<Instance> instances = caller.Instances();`

`IEnumerable<Instance> instances = caller.Instances(x => x.Current());`

***

**Convocations**

_Description:_ Returns list of State Duma's convocations and sessions.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy](http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<Convocation> convocations = caller.Convocations();`

***

**Laws**

_Description:_ Returns list of found laws. Response contains records of laws as well as latest events for each of the law.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam](http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam)

_Code:_ 

`IApiCaller caller = ...`

`LawsSearchResult laws = Laws(call => call.Name("курение").Sorting(LawsSorting.DateDescending));`

***

**Questions**

_Description:_ Returns list of questions of the meetings agend of the State Duma.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi](http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi)

_Code:_

`IApiCaller caller = ...`

`QuestionsSearchResult questions = caller.Questions(x => x.From(new DateTime(2013, 1, 1)).To(new DateTime(2013, 12, 31)).Name("образование").PageSize(PageSize.Five).Page(2)));`

***

**Deputy Info**

_Description:_ Returns detailed information about specific deputy of the State Duma.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate](http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate)

_Code:_

`IApiCaller caller = ...`

`DeputyInfo deputy = caller.Deputy(99100142);`

***

**Deputies Requests**

_Description:_ Returns list of deputies requests.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi](http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi)

_Code:_

`IApiCaller caller = ...`

`IEnumerable<DeputyRequest> requests = caller.Requests();`

***

***

**Transcripts**

***

**By Date**

_Description:_ Returns full transcripts text for given date.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-na-zadannuyu-datu](http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-na-zadannuyu-datu)

_Code:_ 

`IApiCaller caller = ...`

`DateTranscriptsResult transcripts = caller.Transcripts().Date(new DateTime(2013, 5, 14));`

***

**Deputy's speeches**

_Description:_ Returns transcripts of particular deputy's speeches.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata](http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata)

_Code:_ 

`IApiCaller caller = ...`

`DeputyTranscriptsResult transcript = caller.Transcripts().Deputy(id: 99100142, from: new DateTime(2013, 1, 1), to: new DateTime(2013, 12, 31), page: 2, limit: PageSize.Five);`

`DeputyTranscriptsResult transcript = caller.Transcripts().Deputy(call => call.Deputy(99100142).From(new DateTime(2013, 1, 1)).To(new DateTime(2013, 12, 31)).Page(2).PageSize(PageSize.Five));`

***

**Laws**

_Description:_ Returns transcript of given law.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-zakonoproektu](http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-zakonoproektu)

_Code:_ 

`IApiCaller caller = ...`

`LawTranscriptsResult transcripts = caller.Transcripts().Law("140513-6");`

**Questions**

_Description:_ Returns transcripts of Duma's agenda question.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/stenogramma-rassmotreniya-voprosa](http://api.duma.gov.ru/pages/dokumentatsiya/stenogramma-rassmotreniya-voprosa)

_Code:_ 

`IApiCaller caller = ...`

`QuestionTranscriptsResult transcripts = caller.Transcripts().Question(80, 13);`

***

**Resolutions**

_Description:_ Returns transcripts of resolution's draft.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-proektu-postanovleniya](http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-proektu-postanovleniya)

_Code:_ 

`IApiCaller caller = ...`

`ResolutionTranscriptsResult transcripts = caller.Transcripts().Resolution("276569-6");`

***

***

**Voting**

***

**Search**

_Description:_ Performs search through open results of Duma's voting sessions.

_Documentation:_ [http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy](http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy)

_Code:_

`IApiCaller caller = ...`

`VotesSearchResult votes = caller.Votes().Search(from: new DateTime(2011, 12, 21)), this.xmlApiCaller.Votes().Search(from: new DateTime(2011, 12, 21), deputy: 99111987);`

`VotesSearchResult votes = caller.Votes().Search(call => call.From(new DateTime(2011, 12, 21)).Deputy(99111987));`