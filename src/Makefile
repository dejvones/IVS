CC = gmcs
SRC = $(shell find src/ -type -f -name '*.cs')
MAIN_FILE = Calculator

EXECUTABLE = $(MAIN_FILE).exe

all: $(EXECUTABLE)

doc:
        doxygen 

$(EXECUTABLE): $(SRC)
    @ $(CC) $(SRC) -out:$(EXECUTABLE)

clean-bin:
        rm -f $(MAIN_FILE)  

clean-bck:
        rm -f *~ *.bak  

clean: clean-bin clean-bck 
