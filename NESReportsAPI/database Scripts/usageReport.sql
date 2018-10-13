DELIMITER $$


DROP PROCEDURE IF EXISTS `GetDistrict`$$

CREATE PROCEDURE `GetDistrict`(
 IN state VARCHAR(50)
)
BEGIN
          SELECT `Sd_district` FROM `schooldetail` WHERE `Sd_state` = state  GROUP BY  `Sd_district`;
	END$$

DELIMITER ;

/* Procedure structure for procedure `GetState` */





DELIMITER $$
 DROP PROCEDURE IF EXISTS  `GetUsageBranchByStateandDistrict`$$ 
 CREATE  PROCEDURE `GetUsageBranchByStateandDistrict`(
      IN StateCodes VARCHAR(100),
     IN DistrictCodes VARCHAR(100)
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
        AND  BRANCH.`Sd_district` in ( '  , DistrictCodes, ')
        GROUP BY  BRANCH.SD_DISTRICT, BRANCH.SD_NAME; '
        );
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	

	END$$
DELIMITER ;

/* Procedure structure for procedure `GetUsageDistrictByStates` */



DELIMITER $$


DROP PROCEDURE IF EXISTS `GetUsageDistrictByStates`$$

CREATE  PROCEDURE `GetUsageDistrictByStates`(  IN StateCodes VARCHAR(400)   )
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
        GROUP BY  BRANCH.Sd_state, BRANCH.SD_DISTRICT; '
        );
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$

DELIMITER ;

/* Procedure structure for procedure `GetUsageDistrictsByStatesandDistrict` */


DELIMITER $$

DROP PROCEDURE IF EXISTS  `GetUsageDistrictsByStatesandDistrict`$$
 CREATE  PROCEDURE `GetUsageDistrictsByStatesandDistrict`(
     IN StateCodes VARCHAR(100),
     IN DistrictCodes VARCHAR(700)
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
        AND  BRANCH.`Sd_district` in ( '  , DistrictCodes, ')
        GROUP BY  BRANCH.SD_DISTRICT; '
        );
        
     
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	END$$ 
DELIMITER ;

/* Procedure structure for procedure `GetUsageReport` */



DELIMITER $$
DROP PROCEDURE IF EXISTS  `GetUsageReport`$$ 
 CREATE  PROCEDURE `GetUsageReport`(
     IN N_State VARCHAR(100),
     IN N_District VARCHAR(100)
    )
BEGIN

IF(N_State != '' AND N_District != '') THEN

  SELECT 
	     BRANCH.SD_NAME BRANCH, 
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) 'USAGE'
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
      WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.SD_STATE = N_State
        AND  BRANCH.`Sd_district` = N_District
     -- AND  BRA.SD_ID =  260
     -- AND  MUID.UM_YEAR_MONTH BETWEEN STR_TO_DATE('01/10/2018', '%d/%m/%Y') AND STR_TO_DATE('11/10/2018', '%d/%m/%y')
        GROUP BY  BRANCH.SD_STATE, BRANCH.SD_LOCALITY, BRANCH.SD_NAME; 
        
        ELSEIF(N_State != '' AND N_District = '') THEN
        
          SELECT  
	     BRANCH.SD_LOCALITY DISTRICT, 
	     BRANCH.SD_NAME BRANCH, 
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) 'USAGE'
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
      WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        AND  BRANCH.SD_STATE = N_State
       
     -- AND  BRA.SD_ID =  260
     -- AND  MUID.UM_YEAR_MONTH BETWEEN STR_TO_DATE('01/10/2018', '%d/%m/%Y') AND STR_TO_DATE('11/10/2018', '%d/%m/%y')
        GROUP BY  BRANCH.SD_STATE, BRANCH.SD_LOCALITY, BRANCH.SD_NAME; 
        
        
        END IF;
        
        
	END$$ 
DELIMITER ;

/* Procedure structure for procedure `GetUsageStateByStates` */



DELIMITER $$
 DROP PROCEDURE IF EXISTS  `GetUsageStateByStates`$$
 CREATE  PROCEDURE `GetUsageStateByStates`( 
    IN StateCodes VARCHAR(100)
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
        GROUP BY  BRANCH.Sd_state; '
        );
        
     
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;

           

	END$$ 
DELIMITER ;

/* Procedure structure for procedure `GetUsageStateWise` */



DELIMITER $$
 DROP PROCEDURE IF EXISTS  `GetUsageStateWise`$$
 CREATE  PROCEDURE `GetUsageStateWise`(

)
BEGIN

          SELECT 
             BRANCH.SD_STATE AS 'State',
             BRANCH.SD_DISTRICT AS 'District',
	     BRANCH.SD_NAME 'Branch', 
	     SEC_TO_TIME( SUM( TIME_TO_SEC( MUID.UM_OVERALLCTYPE_USAGE))) 'USAGE'
       FROM  SCHOOLDETAIL BRANCH,    -- BRANCH MASTER
  	     SCHOOLLICDETAIL UID, -- USER ID         
	     USAGEMASTER MUID     -- USER ID USAGE         
       WHERE  UID.SLD_SCHOOL_ID = BRANCH.SD_ID
	AND  MUID.UM_LICENSE_ID = UID.SLD_LICENSE_ID
        GROUP BY  BRANCH.SD_STATE, BRANCH.SD_LOCALITY, BRANCH.SD_NAME  ORDER BY BRANCH.SD_STATE ; 
        
	END$$ 
DELIMITER ;



DELIMITER $$

DROP PROCEDURE IF EXISTS `GetUsageBranchByStateandDistrictandBranch`$$


CREATE  PROCEDURE `GetUsageBranchByStateandDistrictandBranch`(
      IN StateCodes VARCHAR(100),
     IN DistrictCodes VARCHAR(100),
     IN BranchCodes VARCHAR(100)
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
        GROUP BY  BRANCH.SD_DISTRICT, BRANCH.SD_NAME; '
        );
		PREPARE myquery FROM @Expression;
		EXECUTE myquery;
	

	END$$

DELIMITER ;