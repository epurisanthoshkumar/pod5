import React,{useState,useEffect} from 'react';
import {TextField} from '@material-ui/core';
import axios from 'axios';
import {v4 as UUID} from "uuid";


function Register()
{
    const [values,setValues] = useState({
        userid :UUID(),
        Username:"",
        Email : "",
        password : "",
        confirmpassword : "",
        address : ""
       // formErrors: {}
    });
    const[datas,setDatas]=useState([]);
   /* const handleSubmit = (e) => {
        e.preventDefault();
        const rec = {...values}
        setDatas([...datas,rec]);*/
       /* useEffect(''+Username+'/'+Email+'/'+password+'/'+confirmpassword+'/'+address,{
            method: 'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then(data=>{console.log(data)}) */

        /*useEffect(()=>{
            const reqAPI = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
            
        
            };*/
            /*const[datas,setDatas]=useState([]);*/

    const HandleSubmit = (e) => {

        e.preventDefault();

        const rec = {...values}

        setDatas([...datas,rec]);

       console.log(datas);

    fetch('http://localhost:58905/User/Reg',{
        method:'POST',
        redirect: "follow",
        headers: {
            'Content-Type': 'application/json'
          },
          body:JSON.stringify(rec)
 }).then(res=>{window.location.href='http://localhost:58905/' })
    .then(data=>{console.log(data)})
}
    const handleInput = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        console.log(name,value);
        setValues({ ...values, [name] : value})
    }

    
    
    
    return(
        
    <div className='main'>

          <h1> Signup Page </h1>
        <form>
        
        <TextField 
        className="UserName" 
        placeholder="UserName" 
        name='Username'
        value={values.Username}
        onChange={handleInput}
       />
        <br/>
        
        <TextField 
        className="Email" 
        placeholder="Email"
        name="Email"
        type='email'
        value={values.Email}
        onChange={handleInput}
         />
         
        <br/>
        <TextField 
        className="Password" 
        placeholder="Password" 
        name='password'
        type='password'
        value={values.password}
        onChange={handleInput}
        
        />
        
        <br/>
        <TextField 
        className="ConfirmPassword" 
        placeholder="ConfirmPassword"
        name='confirmpassword'
        type='password'
        value={values.confirmpassword}
        onChange={handleInput}
        
        />
         
        <br/>
        <TextField 
        className="address" 
        placeholder="address"
        name='address'
        value={values.address}
        onChange={handleInput}
        
        />
        
         
        <br/>
        <br/>
        <br/>
        <button type='submit' onClick={HandleSubmit} className="styc">Register</button>
        </form>
    </div>
        )

}


export default Register;