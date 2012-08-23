ajax jquery calls only work when logged in user is the "SuperUser Account"
otherwise, get unauthorized.  The other account "Denise Leeson" has two children.

changed pDLB_GetAllChildren sql to limit the children to the logged in users children 
based on firstname and lastname, it really should be limited based on login user name, future change

on the edit view, the drop down (selAssociatedParties) of people, should filter those people that already have relationships
or at least not add them twice

the delete on the edit page for lstAssociatedParties list  deleted everyone with the same name
not sure if this is a desirable affect, maybe push the People.Id to client so we delete the correct association

