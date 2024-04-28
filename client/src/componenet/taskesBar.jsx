import React from 'react'
import style from "./style.module.css"
import done from "../assets/Check_ring.png"
import time from "../assets/hour.svg"
import error from "../assets/Question.svg"
import classNames from 'classnames';

const taskesBar = ({taskStatus,taskTache}) => {
 var b1=false;
 var b2=false;
 var b3=false;
 var pics =""; 
 if (taskStatus=="Finiched Tasks"){
   pics=done;
   b1=true;
 }
 else if (taskStatus=="Task Queue"){
   pics =time ; 
   b2=true;
 }
 else {
   pics = error;
   b3=true; 
 }
 const taskBar= classNames(
  b1 && style.taskBar,
    b2 && style.taskBar2,
  b3 && style.taskBar3,
);
const taskTacheclass= classNames(
  b1 && style.taskTache,
    b2 && style.taskTache2,
  b3 && style.taskTache3,
);
const taskStatusclass= classNames(
  b1 && style.taskStatus,
    b2 && style.taskStatus2,
  b3 && style.taskStatus3,
);

 
  return (
    <div className={taskBar } >
        <div className={style.picstaskbar}>
            <img src={pics}/>
        </div>
        <section className={style.task}>
         <p className={style.taskStatus}>{taskStatus}</p>
         <p className={taskTacheclass}>{taskTache}</p>
        </section>
    </div>
  )
}

export default taskesBar
