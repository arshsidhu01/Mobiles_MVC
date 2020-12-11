Add-migration Authorize -context 'ApplicationDbcontext'
update-database Authorize -context 'ApplicationDbcontext'

Add-migration Mobiles -context 'Mobiles_MVCContext'
update-database Mobiles -context 'Mobiles_MVCContext'