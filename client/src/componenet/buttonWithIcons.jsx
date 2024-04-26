import React from 'react'
import style from "./style.module.css"
const buttonWithIcons = ({pics,text}) => {
  return (
  <button className={style.buttonWithIcons}>
    <img src={pics}></img>
    {text}
  </button>
  )
}
export default buttonWithIcons
