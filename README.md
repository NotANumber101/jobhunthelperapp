PURPOSE
    - to track applications and companies
    - to review and practice dsa
    - in-depth post mortem for every solution
    - all "75 hard" practice problems with difficulty and topic properties

REQUIRMENTS
    -dotnet 10
    -docker

INSTALL
    `docker compose up`
    This creates two services
        a. postgres database
        b. this app in Non-interactive mode

RUN interactive terminal
    1. Open new terminal
    2. cd into cdbv1/cdbv1 
    3. execute `dotnet run`

TODO: test sequence

    after dotnet run, the app will confirm db is OK

    test sequence: application feature

    1. select applications in the main menu
    2. confirm mock application is present in applications table
    3. enter yes when prompted, to add new application
    4. confirm 2 companies (sapecx, anduril) are present in companies table
    5. Input: company name, then application status, then description.
    6. Confirm success message " Done.New Application added."
    7. type `n` to reject return to main menu. App will terminate.

    8. Start the app
    9. select applications in the main menu
    10. confirm new application is present, which means that the application table now has 2 applications.
    11. reject the prompt, add new application
    12. confirm the prompt, return to main menu

    ........ to do..... 13, 14 ,15
    test sequence: network feature... coming soon
        



ROADMAP
    [ ] Feature: Network Messaging (important)

    [ ] Feature: Postmortem
            -> timing

    [ ] Feature: DSA SOLUTION PAGE (active)
                -> view all solutions, sorted by most recent

    [ ] Feature: Timer
    [ ] Feature: Testing
    [ ] Feature: CD/CD Pipeline
    [ ] Feature: Pagination (Data: DsaProblem)
        - Problem: Loading too many DsaProblem's creates clutter on the Display
        - Solution: Load only 5 problems and ask user if they would like to load DsaProblem's
    [ ] Feature: Pagination (Data: JobApplication)
        - Problem: Job application can be a very large body of text.
        - Solution: Load summary. Use AI to Create Summary. JobDescription when JobDescription is inserted.
                    - Also, present user with option to load origional job description
    [ ] Feature: Improved Sorting (Data: DsaProblem)

    [ ] Additional Features:
        Feature: Flashcards
        Feature: Problem Scheduler
        Feature: migrate DB to file (persitant storage if volume is deleted)

    [ ] Consider this: create test data for alerting (ie application or message that is 2 weeks old)

BUGS
    [priority] async is totally jacked up. (displays appear sooner than their predecesor)
    [ ] DsaProblemPage. Adding solution. If non of the problems are stale, and the table is empty. They problems are still selected.
        So instead of erroring out, it picks a non stale. This behaviour is actually agreeable.

    [ ] Parameters

////////////////
From the docs... When sending data values to the database, always consider using parameters rather than including the values in the SQL as follows:

await using var cmd = new NpgsqlCommand("INSERT INTO table (col1) VALUES ($1), ($2)", conn)
{
    Parameters =
    {
        new() { Value = "some_value" },
        new() { Value = "some_other_value" }
    }
};

await cmd.ExecuteNonQueryAsync();
///////////////////////




design_time_ms code_time_ms mistakes analysis rubric_problem_solving_score rubric_coding_score rubric_verification_score rubric_communication_score



https://www.npgsql.org/doc/basic-usage.html

https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSource.html

https://gui-cs.github.io/Terminal.Gui/