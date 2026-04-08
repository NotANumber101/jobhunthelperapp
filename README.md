  ___           _                           _                   
 |_ _|  _ __   | |_    ___   _ __  __   __ (_)   ___  __      __
  | |  | '_ \  | __|  / _ \ | '__| \ \ / / | |  / _ \ \ \ /\ / /
  | |  | | | | | |_  |  __/ | |     \ V /  | | |  __/  \ V  V / 
 |___| |_| |_|  \__|  \___| |_|      \_/   |_|  \___|   \_/\_/  
                                                                
  _   _          _                       
 | | | |   ___  | |  _ __     ___   _ __ 
 | |_| |  / _ \ | | | '_ \   / _ \ | '__|
 |  _  | |  __/ | | | |_) | |  __/ | |   
 |_| |_|  \___| |_| | .__/   \___| |_|   
                    |_|                  

REQUIRMENTS
    -dotnet 10
    -docker

INSTALL
    1. `cd cdbv1/cdbv1`
    2. execute `dotnet run`

ROADMAP

    [ ] Feature: Postmortem (active)

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
        Feature: migrate DB to file