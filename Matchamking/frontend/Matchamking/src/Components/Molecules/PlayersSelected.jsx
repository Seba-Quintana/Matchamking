import React, {useState, useEffect} from 'react'
import SelectedPlayer from '../Atoms/SelectedPlayer'

const PlayersSelected = (
  {selectedPlayers, setSelectedPlayers,
   remainingPlayers, setRemainingPlayers}
  ) => {

    const [ playerClicked, setPlayerClicked] = useState();


    useEffect(() => {
      let newArr = selectedPlayers.filter(el => el.playername !== playerClicked.playername);
      let newRemainingPlayers = remainingPlayers;
      setSelectedPlayers(newArr);
      if (playerClicked !== undefined)
          newRemainingPlayers.push(playerClicked)
    }, [playerClicked])

  return (
    <>
        {
            selectedPlayers.map(item => 
                <SelectedPlayer winrate={item.winrate}
                    playername={item.playername}
                    players={selectedPlayers}
                    setPlayers={setRemainingPlayers}
                    setPlayerClicked={setPlayerClicked}
                    key={item.playername}
                ></SelectedPlayer>)
        }
    </>
  )
}

export default PlayersSelected