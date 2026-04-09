PURPOSE
    - to track applications and companies
    - to review and practice dsa
    - in-depth post mortem for every solution
    - all "75 hard" practice problems with difficulty and topic properties

REQUIRMENTS
    -dotnet 10
    -docker

INSTALL
    1. `cd cdbv1/cdbv1`
    2. execute `dotnet run`

ROADMAP

    [ ] Feature: Postmortem (active)

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

BUGS
    [ ] DsaProblemPage. Adding solution. If non of the problems are stale, and the table is empty. They problems are still selected.
        So instead of erroring out, it picks a non stale. This behaviour is actually agreeable.




design_time_ms code_time_ms mistakes analysis rubric_problem_solving_score rubric_coding_score rubric_verification_score rubric_communication_score