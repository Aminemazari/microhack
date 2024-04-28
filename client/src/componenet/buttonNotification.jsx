import React from 'react'
import style from "./style.module.css"
const buttonNotification = ({on,off,picsOff,picsOn,text}) => {
  return (
    <button className={style.buttonNotification} >
     <img src={picsOff}></img>
     {text}
    </button>
  )
}

export default buttonNotification