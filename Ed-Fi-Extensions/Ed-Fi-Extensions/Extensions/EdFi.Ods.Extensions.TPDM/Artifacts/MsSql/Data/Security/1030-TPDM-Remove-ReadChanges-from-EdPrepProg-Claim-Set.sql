-- Remove ReadChanges action from all the 'Education Preparation Program' permissions
DECLARE @claimSetId INT, @actionId INT

SELECT @actionId = ActionId FROM Actions WHERE ActionName = 'ReadChanges'

SELECT @claimSetId = ClaimSetId FROM ClaimSets WHERE ClaimSetName = 'Education Preparation Program'

DELETE FROM ClaimSetResourceClaimActions
WHERE ActionId = @actionId AND ClaimSetId = @claimSetId
