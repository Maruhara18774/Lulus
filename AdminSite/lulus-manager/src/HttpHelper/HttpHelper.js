import axios from "axios";
const endpoint = 'https://localhost:44354/api';
export let currentToken = "";
let config = {};
export function SetToken(value) {
    currentToken = value;
    config = {
      headers: {
        "Authorization": "Bearer "+ currentToken
      }
    };
}
export async function Get(token,url) {
    SetToken(token);
    let result;
    await axios.get(endpoint+url,config).then(
      response => {
        result= response;
      }
    )
    return result;
}

export async function Post(token,url,data) {
    SetToken(token);
    let result;
    await axios.post(endpoint+url,data,config).then(
      response =>{
        result = response;
      }
    );
    return result;
}
