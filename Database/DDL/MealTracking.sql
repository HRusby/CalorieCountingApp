CREATE TABLE MEAL_TRACKING (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    TrackingId INTEGER NOT NULL,
    MealId INTEGER NOT NULL
);

ALTER TABLE MEAL_TRACKING
ADD CONSTRAINT meal_tracking_fk_tracking
FOREIGN KEY (TrackingId)
REFERENCES TRACKING(Id);

ALTER TABLE MEAL_TRACKING
ADD CONSTRAINT meal_tracking_fk_ingredient
FOREIGN KEY (MealId)
REFERENCES MEAL(Id);