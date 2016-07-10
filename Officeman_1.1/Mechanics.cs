using Officeman_1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace OfficeMan_1._1
{
    class Mechanics
    {
        public enum character { stand, jumping, falling };
        public enum game { bird, birds, pause };
        Hashtable CharacterState = new Hashtable();
        Hashtable GameState = new Hashtable();
        char direction;
        
        public Mechanics()
        {
            CharacterState.Add(character.stand, true);
            CharacterState.Add(character.jumping, false);
            CharacterState.Add(character.falling, false);
            GameState.Add(game.bird, false);
            GameState.Add(game.birds, false);
            direction = 'r';
        }

        public Mechanics(Mechanics obj)
        {
            this.direction = obj.direction;
            foreach (DictionaryEntry kvp in obj.GameState)
                this.GameState.Add(kvp.Key, kvp.Value);
            foreach (DictionaryEntry kvp in CharacterState)
                this.CharacterState.Add(kvp.Key, kvp.Value);
        }

        public bool this[game state]
        {
            get
            {
                foreach (DictionaryEntry kvp in GameState)
                    if ((game)kvp.Key == state)
                        return (bool)kvp.Value;
                return false;
            }
            set { GameState[state] = value; }
        }

        public bool this[character state]
        {
            get
            {
                foreach (DictionaryEntry kvp in CharacterState)
                    if ((character)kvp.Key == state)
                        return (bool)kvp.Value;
                return false;
            }
            set { CharacterState[state] = value; }
        }

        public void PegionFly(ref int X)
        {
            X -= 20;
        }

        public void PegionsFly(ref int X, ref int Y)
        {
            X -= 20;
            Y -= 10;
        }

        public void TurnLeft(ref int manX)
        {
            if (manX > 25)
                manX -= 20;
            if (this[character.falling] & direction == 'r')
                if (this[character.falling])
                    Sources.RotateCharacterPictures();
            direction = 'l';
        }

        public void TurnRight(ref int manX)
        {
            if (manX < 390)
                manX += 20;
            if (this[character.falling] & direction == 'l')
                if (this[character.falling])
                    Sources.RotateCharacterPictures();
            direction = 'r';
        }
        public void TurnUp(ref int manY)
        {
            if (manY > 30)
                manY -= 20;
        }

        public void TurnDown(ref int manY)
        {
            if (manY < 390)
                manY += 20;
        }
    }
}
