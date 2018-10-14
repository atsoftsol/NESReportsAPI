DELIMITER $$

DROP PROCEDURE IF EXISTS `GetClassByState`$$

CREATE  PROCEDURE `GetClassByState`( 
IN StateCodes VARCHAR(400),
IN StartDate VARCHAR(20),
IN EndDate VARCHAR(20)
)
BEGIN
      SET @Expression = CONCAT(' SELECT  
	     BRA.SD_NAME "Branch", 
	      CLSM.`sly_name` "Class",
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) "USAGE"
       FROM  onlineusage.SCHOOLDETAIL BRA,    -- BRANCH MASTER
  	     onlineusage.SCHOOLLICDETAIL UID, -- USER ID         
	     onlineusage.USAGEMASTER MUID,    -- USER ID USAGE
	     CONTENT.`SYLLABUSMASTER` CLSM	             
      WHERE  UID.SLD_SCHOOL_ID = BRA.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
	AND  MUID.UM_SLY_ID = CLSM.SLY_ID
	 AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
         AND  BRANCH.`Sd_state` in ( '  , StateCodes, ')
        GROUP BY   BRA.SD_NAME,   CLSM.`sly_name`;'
        );
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$

DELIMITER ;

DELIMITER $$

DROP PROCEDURE IF EXISTS `GetClassByStateandDistrict`$$

CREATE  PROCEDURE `GetClassByStateandDistrict`( 
IN StateCodes VARCHAR(400), 
IN DistrictCodes VARCHAR(500),
IN StartDate VARCHAR(20),
IN EndDate VARCHAR(20)
)
BEGIN
      SET @Expression = CONCAT(' SELECT  
	     BRANCH.SD_NAME "Branch", 
	      CLSM.`sly_name` "Class",
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) "USAGE"
       FROM  onlineusage.SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     onlineusage.SCHOOLLICDETAIL UID, -- USER ID         
	     onlineusage.USAGEMASTER MUID,    -- USER ID USAGE
	     CONTENT.`SYLLABUSMASTER` CLSM	             
      WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
	AND  MUID.UM_SLY_ID = CLSM.SLY_ID
         AND  BRANCH.`Sd_state` in ( ', StateCodes,')
        AND  BRANCH.`Sd_district` in ( ', DistrictCodes,')
         AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
        GROUP BY   BRANCH.SD_NAME,   CLSM.`sly_name`;'
        );
        
        SELECT @Expression;
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$

DELIMITER ;


DELIMITER $$


DROP PROCEDURE IF EXISTS `GetClassByStateandDistrictandBranch`$$

CREATE  PROCEDURE `GetClassByStateandDistrictandBranch`( 
IN StateCodes VARCHAR(500), 
IN DistrictCodes VARCHAR(500),
IN BranchCodes VARCHAR(500),
IN StartDate VARCHAR(20),
IN EndDate VARCHAR(20)
)
BEGIN
      SET @Expression = CONCAT(' SELECT  
	     BRANCH.SD_NAME "Branch", 
	      CLSM.`sly_name` "Class",
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) "USAGE"
       FROM  onlineusage.SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     onlineusage.SCHOOLLICDETAIL UID, -- USER ID         
	     onlineusage.USAGEMASTER MUID,    -- USER ID USAGE
	     CONTENT.`SYLLABUSMASTER` CLSM	             
      WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
	AND  MUID.UM_SLY_ID = CLSM.SLY_ID
         AND  BRANCH.`Sd_state` in ( ', StateCodes,')
        AND  BRANCH.`Sd_district` in ( ', DistrictCodes,')
        AND  BRANCH.`SD_NAME` in ( ' , BranchCodes, ')
         AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
        GROUP BY   BRANCH.SD_NAME,   CLSM.`sly_name`;'
        );
        

		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$

DELIMITER ;

DELIMITER $$

DROP PROCEDURE IF EXISTS `GetUsageBranchByStateandDistrict`$$

CREATE PROCEDURE `GetUsageBranchByStateandDistrict`(
      IN StateCodes VARCHAR(100),
      IN DistrictCodes VARCHAR(100),
      IN StartDate VARCHAR(20),
      IN EndDate VARCHAR(20)
    )
BEGIN
   SET @Expression = CONCAT('SELECT 
         
             BRANCH.SD_NAME As "Branch",
               MUID.UM_YEAR_MONTH "DATES" ,     
	    CAST( SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE)))  AS CHAR  ) "USAGE"
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
       WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.`Sd_state` in ( '  , StateCodes, ')
        AND  BRANCH.`Sd_district` in ( '  , DistrictCodes, ')
          AND (DATE(MUID.UM_YEAR_MONTH) BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
        GROUP BY  BRANCH.SD_DISTRICT, BRANCH.SD_NAME,MUID.UM_YEAR_MONTH ; '
        ); 
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	

	END$$

DELIMITER ;


DELIMITER $$


DROP PROCEDURE IF EXISTS `GetUsageBranchByStateandDistrictandBranch`$$

CREATE  PROCEDURE `GetUsageBranchByStateandDistrictandBranch`(
      IN StateCodes VARCHAR(100),
     IN DistrictCodes VARCHAR(100),
     IN BranchCodes VARCHAR(100),
     IN StartDate VARCHAR(20),
     IN EndDate VARCHAR(20)
    )
BEGIN
   SET @Expression = CONCAT('SELECT 
         
             BRANCH.SD_NAME As "Branch",
	    CAST( SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE)))  AS CHAR  ) "USAGE"
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
       WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.`Sd_state` in ( '  , StateCodes, ')
        AND  BRANCH.`Sd_district` in ( '  , DistrictCodes, '),
         AND  BRANCH.`SD_NAME` in ( '  , BranchCodes, ')
           AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
        GROUP BY  BRANCH.SD_DISTRICT, BRANCH.SD_NAME; '
        );
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	

	END$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS `GetUsageDistrictByStates`$$

CREATE  PROCEDURE `GetUsageDistrictByStates`(  
IN StateCodes VARCHAR(400),
     IN StartDate VARCHAR(20),
     IN EndDate VARCHAR(20)
  )
BEGIN
SET @Expression = CONCAT('SELECT 
             BRANCH.`Sd_state` AS "State",
               BRANCH.SD_DISTRICT AS "District",
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) "USAGE"
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
       WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.`Sd_state` in ( '  , StateCodes, ')
          AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
        GROUP BY  BRANCH.Sd_state, BRANCH.SD_DISTRICT; '
        );
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$

DELIMITER ;


DELIMITER $$


DROP PROCEDURE IF EXISTS `GetUsageDistrictsByStatesandDistrict`$$

CREATE  PROCEDURE `GetUsageDistrictsByStatesandDistrict`(
     IN StateCodes VARCHAR(100),
     IN DistrictCodes VARCHAR(700),
     IN StartDate VARCHAR(20),
     IN EndDate VARCHAR(20)
    )
BEGIN
--     --   BRANCH.`Sd_state` AS "State",
       SET @Expression = CONCAT('SELECT 
     
             BRANCH.SD_DISTRICT AS "District",
	      CAST( SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE)))  AS CHAR  ) "USAGE"
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
       WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.`Sd_state` in ( '  , StateCodes, ')
        AND  BRANCH.`Sd_district` in ( '  , DistrictCodes, '),
            AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StartDate,'") AND DATE("',EndDate,'"))
        GROUP BY  BRANCH.SD_DISTRICT; '
        );
        
     
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS `GetUsageStateByStates`$$

CREATE  PROCEDURE `GetUsageStateByStates`( 
    IN StateCodes VARCHAR(100),
    IN StateDate DATETIME,
    IN EndDate DATETIME
    )
BEGIN
      
      
     SET @Expression = CONCAT('SELECT 
             BRANCH.`Sd_state` AS "State",
	    CAST( SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE)))  AS CHAR  ) "USAGE"
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
       WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.`Sd_state` in ( '  , StateCodes, ')
         AND (DATE(MUID.`um_year_month`)BETWEEN DATE("',StateDate,'") AND DATE("',EndDate,'"))
        GROUP BY  BRANCH.Sd_state; '
        );
        
     
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;

           

	END$$

DELIMITER ;