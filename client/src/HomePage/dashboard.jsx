import style from "./style/dashboard.module.css"
import bar from "../assets/Bar Chart Border Radius.svg"
import TaskesBar from '../componenet/taskesBar'
import SearchBar from '../componenet/searchBar'
import notification from "../assets/Bell_pin.svg"
import Profilecard from "../componenet/profilecard"
import * as React from 'react';
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';

const dashboard = () => {
  const [value, setValue] = React.useState(dayjs('2022-04-17'));
  return (
    <div className={style.hero}>
      <section className={style.firstCountainer}>
        <p className={style.dashboard}>Dashboard</p>
        <div className={style.barCountainer}>
          <img src={bar}></img>
          <TaskesBar taskStatus={"Task Queue"} taskTache={154}/>
          <TaskesBar taskStatus={"Finiched Tasks"} taskTache={254}/>
          <TaskesBar taskStatus={"Task Request"} taskTache={94}/>
        </div>
      </section>

      <section className={style.mainCountainer}>
         <nav className={style.Header}>
            <section className={style.searchANDprofile}>
              <SearchBar></SearchBar>
               <mark className={style.profileNotificationAndAccess}>
                   <img src={notification}></img>
                   <Profilecard username={"Amine Mazari "} pics={""} ></Profilecard>
               </mark>
            </section>
         </nav>
         <nav className={style.filterHeader}>
         <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DemoContainer components={['DateField', 'DateField']}>
        <DateField label="Date" defaultValue={dayjs('2022-04-17')} />
        <DateField
          label="Date"
          value={value}
          onChange={(newValue) => setValue(newValue)}
        />
      </DemoContainer>
    </LocalizationProvider>
         </nav>
      </section>

    </div>
  )
}

export default dashboard
