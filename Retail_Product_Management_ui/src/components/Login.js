import React,{useState,useEffect} from 'react';
import {TextField} from '@material-ui/core';
import axios from 'axios';
import {v4 as UUID} from "uuid";

function Login()
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
return(
        
    <div className='main'>

          <h1> Login Page </h1>
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
        <br/>
        <br/>
        <button type='submit' onClick={HandleSubmit} className="styc">Login</button>
        </form>
    </div>
        )

}


export default Login;