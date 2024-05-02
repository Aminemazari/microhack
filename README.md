# MicroHack 2, MicroClub Hackathon,

## Second Challenge : Feild Task Managment System

### Background:

Businesses that operate across various locations, such as
those in event management, construction, and logistics, face
significant challenges in managing field tasks such as service
calls, installations, inspections, and maintenance. Efficient
management of these tasks is crucial for timely project
completion, resource optimization, and customer
satisfaction. A specialized task management tool can play a
critical role in streamlining workflows, enhancing
communication, and boosting overall productivity

### Challenge Overview:

This challenge invites participants to develop innovative task
management solutions specifically designed for businesses
managing operations across different locations. The solution
should effectively address the unique challenges of field
operations, such as geographic dispersion, varying task
requirements, and the need for real-time communication
and updates. By leveraging advanced technologies, the
proposed system should facilitate seamless coordination
and execution of field tasks, ensuring that all operations are
aligned with the business's goals.

## Our Problem is oriented about :
 - Difficulty for organising tasks for multiple partners,
 - Confidentiality of company's data that accepts the task,
 - Security of client-company's goods,
 - Can't determin where Things geting stucked,
 - Getting too big to manage.

_Let client-company the company looking for the service, and provider-company the company providing it_

## Our Solution :
 - Building a platform to manage the external tasks,
 - Facelitating working with external entities, by definning the external employees scops of work, 
 - quering workers status and location for accurate & efficient work delegating

## Technical Impliementation : 

### Backend :
#### Data :
 - We need to store workers and compnies data,
 - Storing contract details,
 - Keep tracking the tasks data (contract, worker, scope of accessabilty, task time, status)

#### Functionalities :
 - Providing the access to the cross-company tasks info for all the employees acourding to spicific authorization (for example the security agent must know who will come to work and when, but other employees related to the issue should know more like which machine he need to fix, whitch zones he is allowed to be in ..., and other business constains)
 - The ability to monitoring & logging the system events, and orgnize the data in meningful & useful way for managers,

#### Project Architecture :
 - Appling vertical slices architecture with minimal using of domain driven design that match with the nature of hackathon MVP and business intensive application (Task managment)

#### Database & Deployment : 
 - Using PostgreSQL as Production database and SQLite and development database to facilitate the development
 - Postgres database depoloyed indenenently from the app, while deploying the app in fly.io using docker
 - Obviously, for testing and fast changing development Sqlite is very good chouse since it is just a file in your project folder

#### Logging & Error handling
 - Log every api call, and perform global error handling to catch exeption, it is not secure but it can give you very fast feedback about where does things goes wrong so it is good for developement stage but not for production

#### Documentation :
 - Using SwaggerUI as documentation and manual testing tool that facilitate integrating between frontend and backend 

#### Testing :
 - Prefering Integration testing over unit testing because of the lean architecture of losly copled vertical slices and copled horizental layers (all the functionality that effect one thing should be as close as possible) so injecting mocks for unit testing is not usefull here, instead integration testing will give you enough to work but not to much to wast hackathon valuble time

#### Endpoints design : Focus on the main & critical endpoints for the end user, which made it inti-conventional and hard to understand without suitibal docs (not only CRUD api)

#### Integrating AI : using Awan LLM api to add facilitate extracting tasks from projects

