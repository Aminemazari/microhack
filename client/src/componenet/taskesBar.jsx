import React from 'react'
import style from "./style.module.css"
import done from "../assets/Check_ring.png"
import time from "../assets/hour.svg"
import error from "../assets/Question.svg"

const taskesBar = ({taskStatus,taskTache}) => {
  var pics =""; 
  if (taskStatus=="Finiched Tasks"){
    pics=done;
  }
  else if (taskStatus=="Task Queue"){
    pics =time ; 
  }
  else {
    pics = error; 
  }
  return (
    <div className={style.taskBar}>
        <div className={style.picstaskbar}>
            <img src={pics}/>
        </div>
        <section className={style.task}>
         <p className={style.taskStatus}>{taskStatus}</p>
         <p className={style.taskTache}>{taskTache}</p>
        </section>
    </div>
  )
}

export default taskesBar
