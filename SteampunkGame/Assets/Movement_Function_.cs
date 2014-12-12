
    void Update()
    {
        pl_MovementPhysics();
    }
    void pl_MovementPhysics()
    {
        
        vel = Vector3.zero;


        if (moveRight) {
            if (dMomentumR < 1) { dMomentumR += Time.deltaTime * 5.5f; } else { dMomentumR = 1; }
            if (Physics.Raycast(playerObj.transform.position + Vector3.up * rigidbody.collider.bounds.size.y * 0.15f, Vector3.right, out rh, rigidbody.collider.bounds.extents.x + 0.08f))

            { if (rh.collider.tag == "Terrain") { dMomentumR = 0; } }
            if (Physics.Raycast(playerObj.transform.position + Vector3.up * rigidbody.collider.bounds.size.y * 0.98f, Vector3.right , out rh, rigidbody.collider.bounds.extents.x + 0.08f))
            { if (rh.collider.tag == "Terrain") { dMomentumR = 0; } }
            vel += Vector3.right * (moveSpd*0.05f + moveSpd*0.95f * dMomentumR); 

        }
        else if (dMomentumR > 0) { dMomentumR -= Time.deltaTime * 10; } else { dMomentumR = 0; }

        if (moveLeft) {
            if (dMomentumL < 1) { dMomentumL += Time.deltaTime * 5.5f; } else { dMomentumL = 1; }
            if (Physics.Raycast(playerObj.transform.position + Vector3.up * rigidbody.collider.bounds.size.y * 0.15f, Vector3.left, out rh, rigidbody.collider.bounds.extents.x + 0.08f))
            { if (rh.collider.tag == "Terrain") { dMomentumL = 0; } }
            //else if (){}
            if (Physics.Raycast(playerObj.transform.position + Vector3.up * rigidbody.collider.bounds.size.y *0.98f, Vector3.left, out rh, rigidbody.collider.bounds.extents.x + 0.08f))
            { if (rh.collider.tag == "Terrain") {dMomentumL = 0; } }
            vel += Vector3.left * + (moveSpd*0.05f + moveSpd*0.95f * dMomentumL); 
        }
        else if (dMomentumL > 0 ) { dMomentumL -= Time.deltaTime * 10; } else { dMomentumL = 0; }


        if (Physics.Raycast(playerObj.transform.position + Vector3.up * 0.25f, Vector3.down, out rh, 0.08f +0.25f))
        {
            
            if (rh.collider.tag == "Terrain")
            {
                grounded = true; jumpVel = 0;  gPull = 0;
                pulsed = false;
                //tO = 15;
                jumpStacks = 2;

                
                airBorne = false;
            }
        }
        //else if (Physics.Raycast(playerObj.transform.position, Vector3.up, out rh, 0.2f))
        //{
        //    if (rh.collider.tag == "Terrain")
        //    {
        //        grounded = true; jumpVel = 0; gPull = 0;
        //        pulsed = false;
        //        //tO = 20;
        //        jumpStacks = 2;


        //        airBorne = false;
        //    }
        //}
        else
        {
            if (moveJump == 0)
            //&& jumpVel ==0)
            {
                grounded = false;
                //jumpStacks = 2;
            }
            airBorne = true;
        }




        if (Physics.Raycast(playerObj.transform.position, Vector3.up, out rh, rigidbody.collider.bounds.size.y + 0.1f))
        { 
            if (rh.collider.tag == "Terrain")
            {
                grounded = false;
                airBorne = false;
                gPull = 0;
            }
        }
        else if (Physics.Raycast(playerObj.transform.position, Vector3.up, out rh, rigidbody.collider.bounds.size.y - 0.1f))
        {
            if (rh.collider.tag == "Terrain")
            {
                gPull = 0;
                grounded = false;
            }
        }

        if (moveJump > 0)
        {
            //pulse
            //ju
            //if (jumpVel<jumpSpd *2){
            if (!pulsed)
            {
                jumpVel = jumpSpd * 1f;
                pulsed = true;
            }
            //}
            //else{jumpVel = jumpSpd *2;}
                

            if (tO_jump > 0){
                tO_jump--;
                if (jumpVel < jumpSpd * 2)
                {
                    jumpVel += 50;
                }
                else { jumpVel = jumpSpd * 2; }
                if (jumpStacks > 0) { 
                    grounded = true;
                }
            }
        }
        else
        {

            if (jumpStacks > 0)
            {
                tO_jump = 14;
            }
        }
        //if (jumpStacks >0)
        if (grounded) 
        {
            //if (jumpVel ){}
            
            gPull = 0;
        }
        else 
        //if (!grounded)
        {
            if (gPull < 275) { gPull += 5; }
            //else()
            vel += Vector3.down * (g * 4  + gPull*4);
            if (jumpVel >= 0)
            { jumpVel -= 10; }
            else { jumpVel = 0; }

        }

        if (tO_jump <= 0)
        {


            grounded = false;
            
            //pulsed = false;
            //jumpStacks--;
            //if (jumpStacks > 0) { jumpStacks--; }
            //else { jumpStacks = 0; }
        }

        else {
            

        }

        vel += Vector3.up * jumpVel; 
        
        pl_Animation();
        
        
        vel *= 0.02f;
        gameObject.rigidbody.velocity = vel;

    }