DELIMITER **

USE CalorieCounting

-- Initial Data Population
SOURCE InitialUser.sql
SOURCE InitialMetrics.sql
SOURCE InitialMetricConversions.sql

-- Deletion Procs
SOURCE StoredProcs/Deletion/DeleteIngredient_Sp.sql
SOURCE StoredProcs/Deletion/DeleteMeal_Sp.sql
SOURCE StoredProcs/Deletion/DeleteMealIngredient_Sp.sql
SOURCE StoredProcs/Deletion/DeleteTrackingRecord_Sp.sql

-- Insertion Procs;
SOURCE StoredProcs/Insertion/AddIngredient_Sp.sql
SOURCE StoredProcs/Insertion/AddMeal_Sp.sql
SOURCE StoredProcs/Insertion/AddMealIngredient_Sp.sql
SOURCE StoredProcs/Insertion/AddTrackingRecord_Sp.sql
SOURCE StoredProcs/Insertion/AddUser_Sp.sql

-- Selection Procs;
SOURCE StoredProcs/Selection/CheckLogin_Sp.sql
-- SOURCE StoredProcs/Selection/GetAllUserTrackingRecords.sql

-- Updation Procs;
SOURCE StoredProcs/Updation/UpdateIngredient_Sp.sql
SOURCE StoredProcs/Updation/UpdateMeal_Sp.sql
SOURCE StoredProcs/Updation/UpdateMealIngredient_Sp.sql
SOURCE StoredProcs/Updation/UpdateTrackingRecord_Sp.sql

**
DELIMITER ;