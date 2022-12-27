import React, { useEffect, useState } from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import Player from '../Atoms/Player'
import styled from 'styled-components'


const PlayerResults = (
    {selectedPlayers, setSelectedPlayers,
    remainingPlayers, setRemainingPlayers}
) => {

    const [ playerClicked, setPlayerClicked] = useState();

    useEffect(() => {
        let newArr = remainingPlayers.filter(el => el.playername !== playerClicked.playername);
        let newSelectedPlayers = selectedPlayers;
        setRemainingPlayers(newArr);
        if (playerClicked !== undefined)
            newSelectedPlayers.push(playerClicked)
        console.log(playerClicked)
      }, [playerClicked])


  return (
    <>
        {
            remainingPlayers.map(item => 
                <Player winrate={item.winrate}
                    playername={item.playername}
                    players={remainingPlayers}
                    setPlayerClicked={setPlayerClicked}
                    key={item.playername}
                ></Player>
        )}
    </>
  )
}

export default PlayerResults