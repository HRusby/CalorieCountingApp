CREATE TABLE INDIVIDUAL_TRACKING (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    TrackingId INTEGER,
    IngredientId INTEGER
);

ALTER TABLE INDIVIDUAL_TRACKING
ADD CONSTRAINT individual_tracking_fk_tracking
FOREIGN KEY (TrackingId)
REFERENCES TRACKING(Id);

ALTER TABLE INDIVIDUAL_TRACKING
ADD CONSTRAINT individual_tracking_fk_ingredient
FOREIGN KEY (IngredientId)
REFERENCES INGREDIENT(Id);